namespace TaskManager.Controller.Tests;

using Microsoft.AspNetCore.Mvc;
using Moq;
using TrilhaApiDesafio.Controllers;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;
using Xunit;

public class TarefaControllerTests
{
    [Fact]
    public void ObterPorId_Deve_Retornar_Tarefa_Existente()
    {

        var id = 1;
        var tarefa = new Tarefa { Id = id };

        // Arrange
        var context = new Mock<OrganizadorContext>();

        var controller = new TarefaController(context.Object);

        context.Setup(c => c.Tarefas.Find(id)).Returns(tarefa);

        // Act
        var result = controller.ObterPorId(id) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result?.StatusCode);
        Assert.Same(tarefa, result?.Value);
    }


    // [Fact]
    // public void ObterPorId_Deve_Retornar_NotFound_Para_Tarefa_Inexistente()
    // {
    //     // Arrange
    //     var tarefaId = 1;

    //     var contextMock = new Mock<OrganizadorContext>();
    //     contextMock.Setup(c => c.Tarefas.Find(tarefaId)).Returns((Tarefa)null);

    //     var controller = new TarefaController(contextMock.Object);

    //     // Act
    //     var resultado = controller.ObterPorId(tarefaId);

    //     // Assert
    //     Assert.IsType<NotFoundResult>(resultado);
    // }
}
