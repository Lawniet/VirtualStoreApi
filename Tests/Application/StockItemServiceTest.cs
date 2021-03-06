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
    public class StockItemServiceTest : BaseStockItemServiceTest
    {
        protected readonly IStockItemValidator _validator;
        protected readonly IStockItemService _service;

        public StockItemServiceTest()
        {
            ResetRepository();
            _validator = new StockItemValidator();
            _service = new StockItemService(_validator, _repository);
        }

        protected static StockItem GenerateValidStockItem()
        {
            var stockItem = new StockItem
            {
                ProductId = 1,
                StoreId = 1,
                Quantity = 10
            };
            return stockItem;
        }

        public class BasicValidation : StockItemServiceTest
        {
            [Fact]
            public void ShouldValidateNullObjectOnSave()
            {
                var response = _service.Save(null);
                Assert.Contains(response.Messages, m => m.Contains("Nenhum item foi informado"));
            }

            [Fact]
            public void ShouldValidateNullObjectOnDelete()
            {
                var response = _service.Delete(null);
                Assert.Contains(response.Messages, m => m.Contains("Nenhum registro foi informado para remoção."));
            }
        }
        public class AssociationtValidation : StockItemServiceTest
        {
            [Fact]
            public void ShouldValidateProductWithoutId()
            {
                var StockItem = GenerateValidStockItem();
                StockItem.ProductId = 0;
                var response = _service.Save(StockItem);
                Assert.Contains(response.Messages, m => m.Contains("Um produto deve ser associado a este Item"));
            }

            [Fact]
            public void ShouldValidateStoreWithoutId()
            {
                var StockItem = GenerateValidStockItem();
                StockItem.StoreId = 0;
                var response = _service.Save(StockItem);
                Assert.Contains(response.Messages, m => m.Contains("Uma loja deve ser associada a este Item"));
            }
        }

        public class CreationValidation : StockItemServiceTest
        {
            [Fact]
            public void ShouldAddValidStockItem()
            {
                StockItem stockItem = GenerateValidStockItem();

                _service.Save(stockItem);

                var result = _repository.GetById(1);

                Assert.NotNull(result);
                Assert.IsType<StockItem>(result);
                Assert.Equal(10, result.Quantity);

                ResetRepository();
            }
        }

        public class QuantityManangementValidation : StockItemServiceTest
        {
            [Fact]
            public void ShouldIncrementValueToStockItemQuantity()
            {
                var stockItem = GenerateValidStockItem();

                _service.Save(stockItem);

                var stockOperation = new StockOperation
                {
                    StockItemId = 1,
                    OperationType = StockOperationType.Increment,
                    Quantity = 50
                };

                _service.UpdateStock(stockOperation);

                var result = _repository.GetById(1);

                Assert.NotNull(result);
                Assert.IsType<StockItem>(result);
                Assert.Equal(60, result.Quantity);

                ResetRepository();
            }


            [Fact]
            public void ShouldDecrementValueToStockItemQuantity()
            {
                var stockItem = GenerateValidStockItem();

                _service.Save(stockItem);

                var stockOperation = new StockOperation
                {
                    StockItemId = 1,
                    OperationType = StockOperationType.Decrement,
                    Quantity = 10
                };

                _service.UpdateStock(stockOperation);

                var result = _repository.GetById(1);

                Assert.NotNull(result);
                Assert.IsType<StockItem>(result);
                Assert.Equal(0, result.Quantity);

                ResetRepository();
            }

            [Fact]
            public void ShouldPreventDecrementIfOperationQuantityHigherThanExistentQuantity()
            {
                var stockItem = GenerateValidStockItem();

                _service.Save(stockItem);

                var stockOperation = new StockOperation
                {
                    StockItemId = 1,
                    OperationType = StockOperationType.Decrement,
                    Quantity = 50
                };

                var response = _service.UpdateStock(stockOperation);

                var result = _repository.GetById(1);

                Assert.NotNull(result);
                Assert.IsType<StockItem>(result);
                Assert.Contains(response.Messages, m => m.Contains("Não há quantidade suficiente do produto. Informe um valor menor."));

                ResetRepository();
            }

            [Fact]
            public void ShouldPreventIncrementIfOperationQuantityLessThanZero()
            {
                var stockItem = GenerateValidStockItem();

                _service.Save(stockItem);

                var stockOperation = new StockOperation
                {
                    StockItemId = 1,
                    OperationType = StockOperationType.Increment,
                    Quantity = -50
                };

                var response = _service.UpdateStock(stockOperation);

                var result = _repository.GetById(1);

                Assert.NotNull(result);
                Assert.IsType<StockItem>(result);
                Assert.Contains(response.Messages, m => m.Contains("É necessário informar um valor positivo para a quantidade."));

                ResetRepository();
            }

            [Fact]
            public void ShouldDeleteStockItem()
            {
                var stockItem = GenerateValidStockItem();

                _service.Save(stockItem);

                _service.Delete(stockItem);

                var result = _repository.GetById(1);

                Assert.Null(result);

                ResetRepository();
            }
        }
    }
}
