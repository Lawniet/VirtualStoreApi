using Application.Services;
using Application.Validators;
using Domain.Entities;
using Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.Services
{
    public class StoreServiceTest : BaseStoreServiceTest
    {
        protected readonly IValidator<Store> _validator;
        protected readonly IService<Store> _service;

        public StoreServiceTest()
        {
            ResetRepository();
            _validator = new StoreValidator();
            _service = new StoreService(_validator, _repository);
        }

        private static Store GenerateValidStore()
        {
            var store = new Store
            {
                Name = "Store Name",
                Address = "Store Address"
            };
            return store;
        }

        public class BasicValidation : StoreServiceTest
        {
            [Fact]
            public void ShouldValidateNullObjectOnSave()
            {
                var response = _service.Save(null);
                Assert.Contains(response.Messages, m => m.Contains("Nenhuma loja foi informada"));
            }

            [Fact]
            public void ShouldValidateNullObjectOnDelete()
            {
                var response = _service.Delete(null);
                Assert.Contains(response.Messages, m => m.Contains("Nenhum registro foi informado para remoção."));
            }
        }

        public class NameValidation : StoreServiceTest
        {
            private const string NAME_VALIDATION_MESSAGE = "O nome da loja deve ser preenchido";

            [Fact]
            public void ShouldValidateNullStoreName()
            {
                var store = new Store();
                store.Name = null;
                var response = _service.Save(store);
                Assert.Contains(response.Messages, m => m.Contains(NAME_VALIDATION_MESSAGE));
            }

            [Fact]
            public void ShouldValidateEmptyStoreName()
            {
                var store = new Store
                {
                    Name = string.Empty,
                    Address = "Address"
                };
                var response = _service.Save(store);
                Assert.Contains(response.Messages, m => m.Contains(NAME_VALIDATION_MESSAGE));
            }

            [Fact]
            public void ShouldValidateBlankStringStoreName()
            {
                var store = new Store
                {
                    Name = " ",
                    Address = "Address"
                };
                var response = _service.Save(store);
                Assert.Contains(response.Messages, m => m.Contains(NAME_VALIDATION_MESSAGE));
            }

        }

        public class AddressValidation : StoreServiceTest
        {
            private const string ADDRESS_VALIDATION_MESSAGE = "O endereço deve ser preenchido";

            [Fact]
            public void ShouldValidateNullStoreAddress()
            {
                var store = new Store
                {
                    Name = "Store Name",
                    Address = null
                };
                var response = _service.Save(store);
                Assert.Contains(response.Messages, m => m.Contains(ADDRESS_VALIDATION_MESSAGE));
            }

            [Fact]
            public void ShouldValidateEmptyAddress()
            {
                var store = new Store
                {
                    Name = "Store Name",
                    Address = string.Empty
                };
                var response = _service.Save(store);
                Assert.Contains(response.Messages, m => m.Contains(ADDRESS_VALIDATION_MESSAGE));
            }

            [Fact]
            public void ShouldValidateBlankStringAddress()
            {
                var store = new Store
                {
                    Name = "Store Name",
                    Address = " "
                };
                var response = _service.Save(store);
                Assert.Contains(response.Messages, m => m.Contains(ADDRESS_VALIDATION_MESSAGE));
            }
        }

        public class CrudValidation : StoreServiceTest
        {
            [Fact]
            public void ShouldAddValidStore()
            {
                Store store = GenerateValidStore();

                _service.Save(store);

                var result = _repository.GetById(1);

                Assert.NotNull(result);
                Assert.IsType<Store>(result);
                Assert.Equal("Store Name", result.Name);

                ResetRepository();
            }


            [Fact]
            public void ShouldUpdateValidStore()
            {
                var store = GenerateValidStore();

                _service.Save(store);

                var storeToUpdate = GenerateValidStore();
                storeToUpdate.Id = 1;
                storeToUpdate.Name = "Updated Name";
                storeToUpdate.Address = "Updated Address";

                _service.Save(storeToUpdate);

                var result = _repository.GetById(1);

                Assert.NotNull(result);
                Assert.IsType<Store>(result);
                Assert.Equal("Updated Name", result.Name);
                Assert.Equal("Updated Address", result.Address);

                ResetRepository();
            }

            [Fact]
            public void ShouldDeleteStore()
            {
                var store = GenerateValidStore();

                _service.Save(store);

                _service.Delete(store);

                var result = _repository.GetById(1);

                Assert.Null(result);

                ResetRepository();
            }
        }
    }
}
