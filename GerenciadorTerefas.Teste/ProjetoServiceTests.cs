using Domin;
using Domin.Interfaces.Repositories;
using Moq;
using Service;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorTerefas.Teste
{
    public class ProjetoServiceTests
    {
        private readonly Mock<IProjetoRepository> _mockProjetoRepository;
        private readonly Mock<ITarefaRepository> _mockTarefaRepository;
        private readonly ProjetoService _projetoService;

        public ProjetoServiceTests()
        {
            _mockProjetoRepository = new Mock<IProjetoRepository>();
            _mockTarefaRepository = new Mock<ITarefaRepository>();
            _projetoService = new ProjetoService(_mockProjetoRepository.Object, _mockTarefaRepository.Object);
        }

        [Fact]
        public async Task CreateProjetoAsync_ValidProjeto_ReturnsProjeto()
        {
            // Arrange
            var projeto = new ProjetoEntity { Nome = "Projeto Teste 1", IdUsuario = 2 };
            _mockProjetoRepository.Setup(repo => repo.AddAsync(projeto))
                .ReturnsAsync(projeto);

            // Act
            var result = await _projetoService.AddAsync(projeto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(projeto.Nome, result.Nome);
        }

        [Fact]
        public async Task CreateProjetoAsync_ValidProjeto_ReturnsProjeto2()
        {
            // Arrange
            var projeto = new ProjetoEntity { Nome = "Projeto Teste 2", IdUsuario = 1 };
            _mockProjetoRepository.Setup(repo => repo.AddAsync(projeto))
                .ReturnsAsync(projeto);

            // Act
            var result = await _projetoService.AddAsync(projeto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(projeto.Nome, result.Nome);
        }

        [Fact]
        public async Task CreateProjetoAsync_ValidProjeto_ReturnsProjeto3()
        {
            // Arrange
            var projeto = new ProjetoEntity { Nome = "Projeto Teste 3", IdUsuario = 3 };
            _mockProjetoRepository.Setup(repo => repo.AddAsync(projeto))
                .ReturnsAsync(projeto);

            // Act
            var result = await _projetoService.AddAsync(projeto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(projeto.Nome, result.Nome);
        }

        [Fact]
        public async Task CreateProjetoAsync_ValidProjeto_ReturnsProjeto4()
        {
            // Arrange
            var projeto = new ProjetoEntity { Nome = "Projeto Teste 4", IdUsuario = 1 };
            _mockProjetoRepository.Setup(repo => repo.AddAsync(projeto))
                .ReturnsAsync(projeto);

            // Act
            var result = await _projetoService.AddAsync(projeto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(projeto.Nome, result.Nome);
        }

        [Fact]
        public async Task CreateProjetoAsync_NullProjeto_ThrowsArgumentNullException()
        {
            // Arrange
            ProjetoEntity projeto = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _projetoService.AddAsync(projeto));
        }

        [Fact]
        public async Task CreateProjetoAsync_EmptyNome_ThrowsArgumentException()
        {
            // Arrange
            var projeto = new ProjetoEntity { Nome = "" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _projetoService.AddAsync(projeto));
        }
    }

}
