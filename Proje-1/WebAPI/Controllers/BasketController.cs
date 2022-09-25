using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        IBasketService _basketService;
        IBasketProductService _basketProductService;
        ICampaignService _campaignService;
        IProductService _productService;
        public BasketController(IBasketService basketService,IBasketProductService basketProductService,ICampaignService campaignService,IProductService productService)
        {
            _basketService = basketService;
            _basketProductService = basketProductService;
            _campaignService = campaignService;
            _productService = productService;
        }


        [HttpGet("create")]
        public BasketModel Add()
        {
            Basket basket = new Basket();
            basket.guid = Guid.NewGuid().ToString();

            var result=_basketService.Add(basket);
            var data = _basketService.Get2(basket.guid).Data;

            BasketModel returnData = new BasketModel();
            returnData.message = result.Message;
            returnData.value = data;

            return returnData;
        }

        [HttpPost("AddProduct")]
        public ActionResult AddProduct(BasketProduct product)
        {
            var result = _basketProductService.Add(product);

            if (result.Success) return Ok("ürün eklendi");
            else return BadRequest("bir hata oluştu");
        }
        [HttpGet("DeleteProduct")]
        public ActionResult DeleteProduct(int id)
        {
            var data = _basketProductService.Get(id).Data;
            var result = _basketProductService.Delete(data);

            if (result.Success) return Ok("ürün silindi");
            else return BadRequest("bir hata oluştu");
        }

        [HttpGet("GetBasket")]
        public ActionResult GetBasket(int id)
        {
            BasketWithProduct data = new BasketWithProduct();
            data.basket= _basketService.Get(id).Data;
            data.products = _basketProductService.GetProducts(id).ToList();
            data.selectCampaign = _campaignService.Get(data.basket.campaign_id).Data;
            data.totalPrice = data.products.Sum(i => i.product.price * i.count);

            if (data.selectCampaign != null)
            {
                if (data.selectCampaign.campaign_type_id == 2)
                {
                    if (data.selectCampaign.campaign_conditions_id == 1)
                    {
                        if (data.selectCampaign.campaign_effect_id == 2)
                        {
                            foreach (var item in data.products)
                            {
                                if (Array.Exists(data.selectCampaign.effect_which_products, p => p == item.productid) && data.totalPrice >= data.selectCampaign.condition_basket_price)
                                {
                                    item.product.price = 0;
                                }
                            }
                        }
                    }
                    else if (data.selectCampaign.campaign_conditions_id == 2)
                    {
                        if (data.selectCampaign.campaign_effect_id == 2)
                        {
                            bool existConditionItems = false;

                            foreach (var item in data.selectCampaign.condition_which_products)
                            {
                                if (data.products.Exists(i => i.productid == item) && data.products.Where(i => i.productid == item).First().count >= data.selectCampaign.condition_product_count) existConditionItems = true;
                                else
                                {
                                    existConditionItems = false;
                                    break;
                                }
                            }

                            foreach (var item in data.products)
                            {

                                if (Array.Exists(data.selectCampaign.effect_which_products, p => p == item.productid) && existConditionItems)
                                {
                                    item.product.price = 0;
                                }
                            }
                        }
                    }
                    else if (data.selectCampaign.campaign_conditions_id == 6)
                    {
                        if (data.selectCampaign.campaign_effect_id == 2)
                        {
                            bool existConditionItems = false;
                            foreach (var item in data.selectCampaign.condition_which_products)
                            {
                                if (data.products.Exists(i => i.productid == item) && data.products.Where(i => i.productid == item).First().count >= data.selectCampaign.condition_product_count)
                                {
                                    existConditionItems = true;
                                    break;
                                }

                            }

                            foreach (var item in data.products)
                            {
                                if (Array.Exists(data.selectCampaign.effect_which_products, p => p == item.productid) && existConditionItems)
                                {
                                    item.product.price = item.product.price - item.product.price * data.selectCampaign.discount_rate / 100;
                                }
                            }
                        }

                    }
                    else if (data.selectCampaign.campaign_conditions_id == 7)
                    {
                        if (data.selectCampaign.campaign_effect_id == 2)
                        {
                            bool existConditionItems = false;
                            foreach (var item in data.selectCampaign.condition_which_products)
                            {
                                if (data.products.Exists(i => i.productid == item) && data.products.Where(i => i.productid == item).First().count >= data.selectCampaign.condition_product_count)
                                {
                                    existConditionItems = true;
                                    break;
                                }

                            }

                            foreach (var item in data.products)
                            {
                                var totalPrice = data.totalPrice = data.products.Sum(i => i.product.price * i.count);
                                if (Array.Exists(data.selectCampaign.effect_which_products, p => p == item.productid) && existConditionItems)
                                {
                                    data.totalPriceWithCampaign = totalPrice - item.product.price * data.selectCampaign.effect_product_count;
                                }
                            }
                        }

                    }
                    data.totalPrice = data.products.Sum(i => i.product.price * i.count);

                }
                else if (data.selectCampaign.campaign_type_id == 3)
                {
                    if (data.selectCampaign.campaign_conditions_id == 2)
                    {
                        if (data.selectCampaign.campaign_effect_id == 2)
                        {
                            bool existConditionItems = false;
                            foreach (var item in data.selectCampaign.condition_which_products)
                            {
                                if (data.products.Exists(i => i.productid == item) && data.products.Where(i => i.productid == item).First().count >= data.selectCampaign.condition_product_count) existConditionItems = true;
                                else
                                {
                                    existConditionItems = false;
                                    break;
                                }
                            }

                            foreach (var item in data.products)
                            {
                                if (Array.Exists(data.selectCampaign.effect_which_products, p => p == item.productid) && existConditionItems)
                                {
                                    item.product.price = item.product.price - item.product.price * data.selectCampaign.discount_rate / 100;
                                }
                            }
                        }
                        else
                        {
                            bool existConditionItems = false;
                            foreach (var item in data.selectCampaign.condition_which_products)
                            {
                                if (data.products.Exists(i => i.productid == item) && data.products.Where(i => i.productid == item).First().count >= data.selectCampaign.condition_product_count) existConditionItems = true;
                                else
                                {
                                    existConditionItems = false;
                                    break;
                                }
                            }
                            var totalPrice = data.totalPrice = data.products.Sum(i => i.product.price * i.count);
                            if (existConditionItems) data.totalPriceWithCampaign = totalPrice - totalPrice * data.selectCampaign.discount_rate / 100;

                        }

                    }
                    else if (data.selectCampaign.campaign_conditions_id == 4)
                    {
                        if (data.selectCampaign.campaign_effect_id == 1)
                        {
                            var totalPrice = data.totalPrice = data.products.Sum(i => i.product.price * i.count);
                            if (data.selectCampaign.condition_basket_price <= totalPrice)
                            {
                                data.totalPriceWithCampaign = totalPrice - totalPrice * data.selectCampaign.discount_rate / 100;
                            }

                        }
                    }
                }
                else if (data.selectCampaign.campaign_type_id == 5)
                {
                    if (data.selectCampaign.campaign_conditions_id == 5)
                    {
                        if (data.selectCampaign.campaign_effect_id == 1)
                        {
                            var totalPrice = data.products.Sum(i => i.product.price * i.count);
                            if (data.selectCampaign.coupon == data.basket.coupon_code)
                            {
                                data.totalPriceWithCampaign = totalPrice - data.selectCampaign.discount_rate;
                            }
                        }

                    }
                    else
                    {
                        if (data.selectCampaign.campaign_effect_id == 1)
                        {
                            var totalPrice = data.products.Sum(i => i.product.price * i.count);
                            if (data.selectCampaign.coupon == data.basket.coupon_code)
                            {
                                data.totalPriceWithCampaign = totalPrice - totalPrice * data.selectCampaign.discount_rate / 100;
                            }
                        }
                    }

                }
            }


            data.totalPrice = data.products.Sum(i => i.product.price * i.count);
            return Ok(data);
            
        }
        [HttpPost("ChooseCampaign")]
        public ActionResult ChooseCampaign(Basket basket)
        {
            var data = _basketService.Get(basket.id).Data;
            basket.guid = data.guid;
            _basketService.Update(basket);

            return Ok("Kampanya değiştirildi.");
        }

        [HttpGet("FillData")]
        public BasketModel FillData()
        {
            Basket basket = new Basket();
            basket.guid = Guid.NewGuid().ToString();

            var result = _basketService.Add(basket);
            var data = _basketService.Get2(basket.guid).Data;

            BasketModel returnData = new BasketModel();

            returnData.message = data.id.ToString()+" ID'li sepet oluşturuldu ve ürünler eklendi;";
            returnData.value = data;

            for (int i = 1; i < 18; i++)
            {
                BasketProduct b1 = new BasketProduct
                {
                    basket_id = data.id,
                    count = 1,
                    productid = 1
                };

                switch (i)
                {
                    case 1:
                        b1.count = 1;
                        b1.productid = 1;
                        _basketProductService.Add(b1);
                        break;
                    case 2:
                        b1.count = 2;
                        b1.productid = 2;
                        _basketProductService.Add(b1);
                        break;
                    case 3:
                        b1.count = 1;
                        b1.productid = 3;
                        _basketProductService.Add(b1);
                        break;
                    case 4:
                        b1.count = 1;
                        b1.productid = 4;
                        _basketProductService.Add(b1);
                        break;
                    case 5:
                        b1.count = 1;
                        b1.productid = 5;
                        _basketProductService.Add(b1);
                        break;
                    case 6:
                        b1.count = 1;
                        b1.productid = 6;
                        _basketProductService.Add(b1);
                        break;
                    case 7:
                        b1.count = 2;
                        b1.productid = 7;
                        _basketProductService.Add(b1);
                        break;
                    case 8:
                        b1.count = 1;
                        b1.productid =8;
                        _basketProductService.Add(b1);
                        break;
                    case 9:
                        b1.count = 1;
                        b1.productid = 9;
                        _basketProductService.Add(b1);
                        break;
                    case 10:
                        b1.count = 3;
                        b1.productid = 10;
                        _basketProductService.Add(b1);
                        break;
                    case 11:
                        b1.count = 1;
                        b1.productid = 11;
                        _basketProductService.Add(b1);
                        break;
                    case 12:
                        b1.count = 2;
                        b1.productid = 12;
                        _basketProductService.Add(b1);
                        break;
                    case 13:
                        b1.count = 2;
                        b1.productid = 13;
                        _basketProductService.Add(b1);
                        break;
                    case 14:
                        b1.count = 4;
                        b1.productid = 14;
                        _basketProductService.Add(b1);
                        break;
                    case 15:
                        b1.count = 1;
                        b1.productid = 15;
                        _basketProductService.Add(b1);
                        break;
                    case 16:
                        b1.count = 1;
                        b1.productid = 16;
                        _basketProductService.Add(b1);
                        break;
                    case 17:
                        b1.count = 1;
                        b1.productid = 17;
                        _basketProductService.Add(b1);
                        break;
                }
            }


            returnData.message = data.id.ToString() + " ID'li sepet oluşturuldu ve ürünler eklendi;";
            returnData.value = data;
            return returnData;
        }

    }
}
