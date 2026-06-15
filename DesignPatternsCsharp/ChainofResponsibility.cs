using System;					
public class RunChainofResponsibility : IDesingPattern
{
  public void Run()
	{
        processo processo = new processo();
        processo.nome = "Processo contra o Shopping";
        processo.status = statusProcesso.ativo;
        processo.responsavel = "João Alencar dos santos";
        processo.responsavelemail = "joaoalencardossantos@example.org";
        processo.temnotificacao = true;
        processo.conteudodanotificacao = "Audiência do processo foi alterada para segunda-feira as 8 horas";

        processoHandler validacao = new ValidacaoPropriedadesdoProcessohandler();
        processoHandler checapornotificacao = new checaporNotificacoesdoProcessohandler();
        
        validacao.SetSucessor(checapornotificacao);

        Console.WriteLine("Primeira tentativa de salvar processo:");
        validacao.HandleRequest(processo);

        Console.WriteLine("Segunda tentativa de salvar processo:");
        validacao.HandleRequest(processo);
    }
}

public class checaporNotificacoesdoProcessohandler : processoHandler
{
    public override void HandleRequest(processo p)
    {
        if (p.temnotificacao == true && !string.IsNullOrEmpty(p.responsavelemail))
        {
            Console.WriteLine("Notificação sendo enviada para {1} ...",
                            p.conteudodanotificacao,p.responsavelemail);
            p.temnotificacao = false;
        } else
        {
            Console.WriteLine("Não há notificações.");
        }
    }
}
public class ValidacaoPropriedadesdoProcessohandler : processoHandler
{
    public override void HandleRequest(processo p)
    {
        if (!string.IsNullOrEmpty(p.nome) && !string.IsNullOrEmpty(p.responsavel))
        {
            Console.WriteLine("{0} é válido.", p.nome);
            sucessor.HandleRequest(p);
        } else
        {
            Console.WriteLine("{0} não é válido.", p.nome);
        }
    }
}
public abstract class processoHandler
{
    protected processoHandler sucessor;
    public void SetSucessor(processoHandler sucessor){
        this.sucessor = sucessor;
    }
    public abstract void HandleRequest(processo processo);
}

public class processo {
    public string nome;
    public statusProcesso status;
    public string responsavel;
    public string responsavelemail;
    public bool temnotificacao;
    public string conteudodanotificacao;
}

public enum statusProcesso{
    ativo,
    inativo,
}
