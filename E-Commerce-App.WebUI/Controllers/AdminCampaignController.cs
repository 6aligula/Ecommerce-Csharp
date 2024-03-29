﻿using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.Core.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.Helpers.UIHelper;

namespace E_Commerce_App.WebUI.Controllers
{
    // EJECUTE EL ENVÍO DEL PRODUCTO ADMIN SI LA VALIDACIÓN ES CORRECTA.

    // Al eliminar una categoría TODO, no olvides eliminar todas las filas que contienen la categoría de product_category
    [Authorize(Roles = "admin")]
    public class AdminCampaignController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<Campaign> _campaignService;
        public AdminCampaignController(IService<Campaign> campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await GetCampaigns());
        }
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {


            var campaign = await _campaignService.GetByIdAsync(id);
            if (id == 0 && campaign == null)
                return View(new CampaignDto());
            else
                return View(_mapper.Map<CampaignDto>(campaign));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] CampaignDto campaignDto, IFormFile campainImage)
        {
            if (ModelState.IsValid)
            {
                if (campainImage != null)
                    campaignDto.ImagePath = await Helpers.ImageHelper.SaveImage(campainImage);
                if (campaignDto.Id == 0)
                {
                    campaignDto.CreationDate = DateTime.Now;
                    await _campaignService.AddAsync(_mapper.Map<Campaign>(campaignDto));
                }
                else
                {
                    campaignDto.DateOfUpdate = DateTime.Now;
                    _campaignService.Update(_mapper.Map<Campaign>(campaignDto));
                }
                return Json(new { isValid = true, message = Messages.JSON_CREATE_MESSAGE("Oferta"), html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCampaigns", await GetCampaigns()) });
            }
            return Json(new { isValid = false, message = Messages.JSON_CREATE_MESSAGE("Oferta", false), html = Helpers.UIHelper.RenderRazorViewToString(this, "AddOrEdit", campaignDto) });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var campaign = await _campaignService.GetByIdAsync(id);
                if (campaign != null)
                    _campaignService.Remove(campaign);
                return Json(new { isValid = true, message = Messages.JSON_REMOVE_MESSAGE("Oferta"), html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCampaigns", await GetCampaigns()) });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        // Get All Campaigns
        public async Task<IEnumerable<CampaignDto>> GetCampaigns()
            => _mapper.Map<IEnumerable<CampaignDto>>(await _campaignService.GetAllAsync());
    }
}
