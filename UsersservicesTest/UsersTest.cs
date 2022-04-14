using System;
using System.Collections.Generic;
using UsersApi.Models;
using UsersApi.Controllers;
using UsersApi.Services;
using Xunit;
using Microsoft.AspNetCore.Mvc;
 

namespace UsersservicesTest
{
    public class UsersTest
    {
        //private readonly List<User> userdata;
        private readonly UsersController controller;
        private readonly UserServices service;
        public UsersTest()
        {
            service = new UserServices();
          controller = new UsersController(service);

            //userdata1 = new List<User>()
            //{
            //    new User() {id= 1,name= "Leanne Graham",Username= "Bret",email= "Sincere@april.biz" },
            //    new User() {id= 2,name= "Ervin Howell",Username= "Antonette",email= "Shanna@melissa.tv"},
            //     new User() {id= 3,name= "Clementine Bauch",Username="Samantha",email= "Nathan@yesenia.net"}
            //};

        }


        [Fact]
        
        public  void AddingUser()
        {
            User userdata = new User()
            {
                id = 1,
                name = "Leanne Graham",
                Username = "Bret",
                email = "Sincere@april.biz",
                address=new List<addresslist>
                {
                    new addresslist()
                    {
                        street = "Kulas Light",
                        suite = "Apt. 556",
                        city = "Gwenborough",
                        zipcode = "92998-3874",
                        geo=new List<geolist>
                        {
                            new geolist()
                            {
                                lat= "-37.3159",
                                lng= "81.1496"
                            }
                        }
                    }
                },
                phone= "1-770-736-8031 x56442",
                website= "hildegard.org",
                company=new List<companylist>()
                {
                    new companylist()
                    {
                         name= "Romaguera-Crona",
                         catchPhrase= "Multi-layered client-server neural-net",
                         bs= "harness real-time e-markets"
                    }
                }
            };

            var addresult = controller.Create(userdata);
            Assert.IsType<CreatedAtActionResult>(addresult);
        }

        [Fact]
        public void ReturnsAllItems()
        {
            
            var okResult = controller.GetAllItem();
            // Assert
            var items = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void RetrunOneItemDetails()
        {
            int id = 1;
            var okResult = controller.Get(id);
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        
        [Fact]
        public void Update_Oneitem()
        {
            User userdata = new User()
            {
                id = 1,
                name = "siva",
                Username = "Bret",
                email = "Sincere@april.biz",
                address = new List<addresslist>
                {
                    new addresslist()
                    {
                        street = "Kulas Light",
                        suite = "Apt. 556",
                        city = "Gwenborough",
                        zipcode = "92998-3874",
                        geo=new List<geolist>
                        {
                            new geolist()
                            {
                                lat= "-37.3159",
                                lng= "81.1496"
                            }
                        }
                    }
                },
                phone = "1-770-736-8031 x56442",
                website = "hildegard.org",
                company = new List<companylist>()
                {
                    new companylist()
                    {
                         name= "Romaguera-Crona",
                         catchPhrase= "Multi-layered client-server neural-net",
                         bs= "harness real-time e-markets"
                    }
                }
            };
            var noContentResponse = controller.update(userdata.id,userdata);
            Assert.IsType<NoContentResult>(noContentResponse);

        }
        [Fact]
        public void Remove_Existingid_RemovesOneItem()
        {

            int id = 1;
            var noContentResponse = controller.Delete(id);
            Assert.IsType<NoContentResult>(noContentResponse);

        }
    }
}
