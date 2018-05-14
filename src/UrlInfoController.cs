using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Litium.Foundation.Modules.CMS;
using Litium.Foundation.Modules.CMS.WebSites;
using Litium.Foundation.Modules.ExtensionMethods;
using Litium.Products;
using Litium.Web.Administration.WebApi;

namespace Litium.Accelerator.WebForm.Site.Administration.Api
{
    public class UrlInfoController : BackofficeApiController
    {
        private readonly BaseProductService _baseProductService;
        private readonly CategoryService _categoryService;
        private readonly ModuleCMS _moduleCms;

        public UrlInfoController(BaseProductService baseProductService, ModuleCMS moduleCms, CategoryService categoryService)
        {
            _baseProductService = baseProductService;
            _moduleCms = moduleCms;
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<WebsiteUrlInfo> Get(string id)
        {
            var result = new List<WebsiteUrlInfo>();
            if (string.IsNullOrEmpty(id))
                return result;

            var isGuidId = Guid.TryParse(id, out var guidId);
            var baseProduct = isGuidId ? _baseProductService.Get(guidId) : _baseProductService.Get(id);
            Category category = null;
            if (baseProduct == null)
            {
                category = isGuidId ? _categoryService.Get(guidId) : _categoryService.Get(id);
                if (category == null)
                    return result;
            }

            foreach (var webSite in _moduleCms.WebSites)
            {
                var urls = baseProduct != null ? GetWebsiteUrls(baseProduct, webSite) : GetWebsiteUrls(category, webSite);

                if (urls.Any())
                    result.Add(new WebsiteUrlInfo
                    {
                        Name = webSite.Name,
                        Urls = urls
                    });
            }

            return result;
        }

        private List<UrlInfo> GetWebsiteUrls(BaseProduct baseProduct, WebSite webSite)
        {
            var urls = new List<UrlInfo>();
            var variants = baseProduct.GetPublishedVariants(webSite.ID).ToList();

            foreach (var baseProductCategoryLink in baseProduct.CategoryLinks)
            {
                var category = _categoryService.Get(baseProductCategoryLink.CategorySystemId);
                var baseProductUrl = baseProduct.GetUrl(webSite.ID, true, category);
                if (!string.IsNullOrEmpty(baseProductUrl))
                    urls.Add(new UrlInfo
                    {
                        Id = baseProduct.Id,
                        Url = baseProductUrl
                    });

                foreach (var variant in variants)
                {
                    var variantUrl = variant.GetUrl(webSite.ID, true, category);
                    if (string.IsNullOrEmpty(variantUrl))
                        continue;

                    if (urls.Any(u => u.Url.Equals(variantUrl)))
                        continue;

                    urls.Add(new UrlInfo
                    {
                        Id = variant.Id,
                        Url = variantUrl
                    });
                }
            }

            return urls;
        }

        private List<UrlInfo> GetWebsiteUrls(Category category, WebSite webSite)
        {
            var urls = new List<UrlInfo>();
            var url = category.GetUrl(webSite.ID, true);
            if (!string.IsNullOrEmpty(url))
                urls.Add(new UrlInfo
                {
                    Id = category.Id,
                    Url = url
                });

            return urls;
        }

        public class WebsiteUrlInfo
        {
            public string Name { get; set; }
            public List<UrlInfo> Urls { get; set; } = new List<UrlInfo>();
        }

        public class UrlInfo
        {
            public string Id { get; set; }
            public string Url { get; set; }
        }
    }
}