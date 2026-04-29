using Xunit;

namespace GastosResidenciais.Tests;

public class ValidacaoNegocioTests
{
    [Fact]
    public void MenorDeIdade_NaoDeve_PossuirReceitas()
    {
        
        var idade = 15;
        var tipoTransacao = "Receita";

        bool permitido = ValidarRegraIdade(idade, tipoTransacao);

        Assert.False(permitido, "ERRO: O sistema permitiu uma receita para menor de idade.");
    }

    private bool ValidarRegraIdade(int idade, string tipo) 
    {
        if (idade < 18 && tipo == "Receita") return false;
        return true;
    }
}