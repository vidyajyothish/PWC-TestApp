using MediatR;
using Moq;
using PWC_TestApp.Commands;
using PWC_TestApp.Controllers;
using PWC_TestApp.Handlers;
using PWC_TestApp.Models;
using PWC_TestApp.Queries;
using PWC_TestApp.Repositories;

namespace PWC_TestApp.Test
{
    public class CientTest
    {
        private readonly Mock<IClientRepository> mockClientRepository;
        private CancellationToken cancellationToken;
        public CientTest()
        {
            mockClientRepository = new();
            cancellationToken = new();
        }

        [Fact]
        public async Task Handle_Should_Return_TrueValue_OnSuccess()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            mockClientRepository.Setup(x => x.AddClientAsync(It.IsAny<Client>())).ReturnsAsync(true);
               
            var command = new CreateClientCommand("Test Client", "email@test.com", DateTime.Now);
            var handler = new CreateClientHandler(mockClientRepository.Object);

            //Act
            bool IsAdded = await handler.Handle(command, cancellationToken);
            //Assert
            Assert.True(IsAdded);
        }
        [Fact]
        public async Task Handle_ShouldReturn_Value1_OnSuccessfulUpdate()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            mockClientRepository.Setup(x => x.UpdateClientAsync(It.IsAny<Client>())).ReturnsAsync(1);

            var command = new UpdateClientCommand(2,"Test","testEmail",DateTime.Now);
            var handler = new UpdateClientHandler(mockClientRepository.Object);

            //Act
            int IsUpdated = await handler.Handle(command, cancellationToken);
            //Assert
            mediatorMock.Setup(s => s.Send(It.IsAny<UpdateClientCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1).Verifiable();
        }

        [Fact]
        public async Task Handle_ShouldReturn_Value0_OnUpdate_IfNoSuchClientIdExist()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            mockClientRepository.Setup(x => x.UpdateClientAsync(It.IsAny<Client>())).ReturnsAsync(0);

            var command = new UpdateClientCommand(2, "Test", "testEmail", DateTime.Now);
            var handler = new UpdateClientHandler(mockClientRepository.Object);

            //Act
            int IsUpdated = await handler.Handle(command, cancellationToken);
            //Assert
           Assert.Equal(0, IsUpdated);
        }

        [Fact]
        public async Task Handle_ShouldReturn_Value1_OnSuccessfulDelete()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            mockClientRepository.Setup(x => x.DeleteClientAsync(It.IsAny<int>())).ReturnsAsync(1);

            var command = new DeleteClientCommand();
            var handler = new DeleteClientHandler(mockClientRepository.Object);          
            
            //Assert
            mediatorMock.Setup(s => s.Send(It.IsAny<DeleteClientCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1).Verifiable();
        }
        [Fact]
        public async Task Handle_ShouldReturn_Value0_IfNoSuchIdExist()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            mockClientRepository.Setup(x => x.DeleteClientAsync(It.IsAny<int>())).ReturnsAsync(1);

            var command = new DeleteClientCommand();
            var handler = new DeleteClientHandler(mockClientRepository.Object);

            //Act
            int IsDeleted = await handler.Handle(command, cancellationToken);

            //Assert
            Assert.Equal(0, IsDeleted);
        }
        [Fact]
        public async Task Handle_ShouldReturn_ClentDetail_IfClientExist()
        {
            //Arrange
            var client = new Client()
            {
                ClientId = 1,
                ClientEmail = "test",
                ClientName = "testName",
                JoinedDate= DateTime.Now,
            };
            mockClientRepository.Setup(x => x.GetClientByIdAsync(It.IsAny<int>())).ReturnsAsync(client);

            var query = new GetClientByIdQuery();
            var handler = new GetClientByIdHandler(mockClientRepository.Object);

            //Act
            Client clientDetails = await handler.Handle(query, cancellationToken);

            //Assert
            Assert.Equal(clientDetails,client);
        }
    }
}