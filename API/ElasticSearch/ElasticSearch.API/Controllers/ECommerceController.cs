﻿using ElasticSearch.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.API.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class ECommerceController : ControllerBase
    {
        private readonly IECommerceService _eCommerceService;
        private readonly ILogger<ECommerceController> _logger;
        public ECommerceController(IECommerceService eCommerceService, ILogger<ECommerceController> logger)
        {
            _eCommerceService = eCommerceService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> TermQuery(string customerFirstName)
        {
            return Ok(await _eCommerceService.TermQuery(customerFirstName));
        }

        [HttpPost]
        public async Task<IActionResult> TermsQuery(List<string> customerFirstNameList)
        {
            return Ok(await _eCommerceService.TermsQuery(customerFirstNameList));
        }

        [HttpGet]
        public async Task<IActionResult> PrefixQuery(string customerFullName)
        {
            return Ok(await _eCommerceService.PrefixQuery(customerFullName));
        }

        [HttpGet]
        public async Task<IActionResult> RangeQuery(double fromPrice, double toPrice)
        {
            return Ok(await _eCommerceService.RangeQuery(fromPrice, toPrice));
        }

        [HttpGet]
        public async Task<IActionResult> RangeQueryPriceAndDate(double fromPrice, double toPrice, DateTime fromDate, DateTime toDate)
        {
            return Ok(await _eCommerceService.PriceRangeQueryByDate(fromPrice, toPrice, fromDate, toDate));
        }

        [HttpGet]
        public async Task<IActionResult> DateRangeQuery(DateTime fromDate, DateTime toDate)
        {
            return Ok(await _eCommerceService.DateRangeQuery(fromDate, toDate));
        }

        [HttpGet]
        public async Task<IActionResult> MatchAllQuery()
        {
			_logger.LogInformation("MatchAllQuery log");
			return Ok(await _eCommerceService.MatchAllQuery());
        }

        [HttpGet]
        public async Task<IActionResult> PaginationQuery(int page=1, int pageSize=3)
        {
            return Ok(await _eCommerceService.PaginationQuery(page, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> WildCardQuery(string customerFullName)
        {
            return Ok(await _eCommerceService.WildCardQuery(customerFullName));
        }

        [HttpGet]
        public async Task<IActionResult> FuzzyQuery(string customerFirstName)
        {
            return Ok(await _eCommerceService.FuzzyQuery(customerFirstName));
        }

        [HttpGet]
        public async Task<IActionResult> MatchFullTextQuery(string category)
        {
            return Ok(await _eCommerceService.MatchQueryFullText(category));
        }

        [HttpGet]
        public async Task<IActionResult> MultiMatchFullTextQuery(string name)
        {
            return Ok(await _eCommerceService.MultiMatchQueryFullText(name));
        }

        [HttpGet]
        public async Task<IActionResult> MatchBoolPrefixFullTextQuery(string customerFullName)
        {
            return Ok(await _eCommerceService.MatchBoolPrefixQueryFullText(customerFullName));
        }

        [HttpGet]
        public async Task<IActionResult> MatchPhraseFullTextQuery(string customerFullName)
        {
            return Ok(await _eCommerceService.MatchPhraseQueryFullText(customerFullName));
        }

        [HttpGet]
        public async Task<IActionResult> CompoundQuery(string cityName, double taxfulTotalPrice, string category, string manufacturer)
        {
            return Ok(await _eCommerceService.CompoundQuery(cityName, taxfulTotalPrice, category, manufacturer));
        }

        [HttpGet]
        public async Task<IActionResult> CompoundFullTextAndPrefixQuery(string customerFullName)
        {
            return Ok(await _eCommerceService.CompoundFullTextAndTermQuery(customerFullName));
        }
    }
}
