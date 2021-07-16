using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PotentialCrudAPI.Controllers;
using PotentialCrudApplication.Dto;
using PotentialCrudApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotentialCrudApiTest.Controllers
{
    public class DesenvolvedorControllerTest
    {
        private Mock<IApplicationServiceDesenvolvedor> applicationServiceDesenvolvedorMock;
        private DesenvolvedorController desenvolvedorController;

        #region *** Setup ***

        [SetUp]
        public void Setup()
        {
            applicationServiceDesenvolvedorMock = new Mock<IApplicationServiceDesenvolvedor>();

            SetupMockGetAll();
            SetupMockGetById();
            SetupMockGetByQueryString();

            SetupMockPost();

            SetupMockPut();

            SetupMockDelete();

            desenvolvedorController = new DesenvolvedorController(applicationServiceDesenvolvedorMock.Object);
        }

        private void SetupMockGetAll()
        {
            applicationServiceDesenvolvedorMock.Setup(x => x.GetAll()).Returns(new List<DesenvolvedorDto>() {
                new DesenvolvedorDto
                {
                    Id = 1,
                    Nome = "Ada Lovelace",
                    Idade = 20,
                    DataNascimento = "25/02/1990",
                    Hobby = "Criar algoritmos",
                    Sexo = "F"
                },
            new DesenvolvedorDto{
                    Id = 2,
                    Nome = "Alan Turing",
                    Idade = 30,
                    DataNascimento = "25/02/1990",
                    Hobby = "Estudar",
                    Sexo = "F"
            } });
        }

        private void SetupMockGetById()
        {
            applicationServiceDesenvolvedorMock.Setup(x => x.GetListById(1)).Returns(new List<DesenvolvedorDto>()
            {
                new DesenvolvedorDto()
                {
                    Id = 1,
                Nome = "Ada Lovelace",
                Idade = 20,
                DataNascimento = "25/02/1990",
                Hobby = "Criar algoritmos",
                Sexo = "F"
                }                
            });
        }

        private void SetupMockGetByQueryString()
        {
            applicationServiceDesenvolvedorMock.Setup(x => x.GetByQueryString("Lin", null, null)).Returns(new List<DesenvolvedorDto>() 
            {
                new DesenvolvedorDto
                {
                    Id = 5,
                Nome = "Abraham Lincoln",
                Idade = 56,
                DataNascimento = "25/02/1990",
                Hobby = "Governar a America",
                Sexo = "M"
                }
            });
        }

        private void SetupMockPost()
        {
            var devMarston = new DesenvolvedorDto()
            {
                Id = 0,
                Nome = "Marston"
            };

            applicationServiceDesenvolvedorMock.Setup(x => x.Add(devMarston)).Returns(5);
        }

        private void SetupMockPut()
        {            
            applicationServiceDesenvolvedorMock.Setup(x => x.Update(new DesenvolvedorDto()));
        }

        private void SetupMockDelete()
        {
            applicationServiceDesenvolvedorMock.Setup(x => x.Remove(1)).Throws(new Exception());
            applicationServiceDesenvolvedorMock.Setup(x => x.Remove(2));
        }

        #endregion

        #region *** Get ***

        [Test]
        public void GetAll_Com_Dois_Registros()
        {
            var resultado = desenvolvedorController.Get();

            var resultadoOk = resultado as OkObjectResult;

            var desenvolvedores = resultadoOk.Value as List<DesenvolvedorDto>;
            var dev1 = desenvolvedores.Where(x => x.Id == 1).FirstOrDefault();
            var dev2 = desenvolvedores.Where(x => x.Id == 2).FirstOrDefault();

            Assert.AreEqual(200, resultadoOk.StatusCode);

            Assert.IsNotNull(dev1);
            Assert.IsNotNull(dev2);

            Assert.AreEqual("Ada Lovelace", dev1.Nome);
            Assert.AreEqual("Alan Turing", dev2.Nome);
        }

        [Test]
        public void Get_By_Id()
        {
            var resultado = (OkObjectResult)desenvolvedorController.Get(1);            
            var dev = (resultado.Value as List<DesenvolvedorDto>).FirstOrDefault();

            Assert.AreEqual(200, resultado.StatusCode);            
            Assert.IsNotNull(dev);
            Assert.AreEqual("Ada Lovelace", dev.Nome);
        }

        [Test]
        public void Get_By_Id_NotFound()
        {
            var resultado = (NotFoundResult)desenvolvedorController.Get(20);
            Assert.AreEqual(404, resultado.StatusCode);
        }

        [Test]
        public void Get_By_QueryString_NotFound()
        {
            var resultado = (NotFoundResult)desenvolvedorController.Get("John", null, null);
            Assert.AreEqual(404, resultado.StatusCode);
        }

        [Test]
        public void Get_By_QueryString()
        {
            var resultado = (OkObjectResult)desenvolvedorController.Get("Lin", null, null);            

            var dev = (resultado.Value as List<DesenvolvedorDto>).FirstOrDefault();

            Assert.AreEqual(200, resultado.StatusCode);
            Assert.IsNotNull(dev);
            Assert.AreEqual("Abraham Lincoln", dev.Nome);            
        }


        #endregion

        #region *** Post ***

        [Test]
        public void PostSucess()
        {            
            var resultado = (CreatedAtActionResult)desenvolvedorController.Post(new DesenvolvedorDto());
            Assert.AreEqual(201, resultado.StatusCode);
        }

        [Test]
        public void PostFail()
        {
            var resultado = (BadRequestObjectResult)desenvolvedorController.Post(null);
            Assert.AreEqual(400, resultado.StatusCode);
        }

        #endregion

        #region *** Put ***

        [Test]
        public void PutSucess()
        {
            var resultado = (OkResult)desenvolvedorController.Put(new DesenvolvedorDto());
            Assert.AreEqual(200, resultado.StatusCode);
        }


        [Test]
        public void PutFail()
        {
             var resultado = (BadRequestObjectResult)desenvolvedorController.Put(null);
            Assert.AreEqual(400, resultado.StatusCode);
        }
        #endregion

        #region *** Delete ***

        [Test]
        public void DeleteSucess()
        {
            var resultado = (NoContentResult)desenvolvedorController.Delete(2);
            Assert.AreEqual(204, resultado.StatusCode);
        }
        
        [Test]
        public void DeleteFail()
        {
            var resultado = (BadRequestObjectResult)desenvolvedorController.Delete(1);
            Assert.AreEqual(400, resultado.StatusCode);
        }

        #endregion

    }
}
