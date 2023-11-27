namespace SportsECommerce.Models
{   
    public interface ICadastro
    {
        public long? CadastroID { get; set; }
        public string CadastroNome { get; set; }
        public string CadastroCPF { get; set; }
        public string CadastroEmail { get; set; }
        public string CadastroTelefone { get; set; }
        public string CadastroEndereco { get; set; }
        public string CadastroMuunicipio { get; set; }
        public string CadastroUF { get; set; }
        public string CadastroCEP { get; set; }

    }
    public class Cadastro : ICadastro
    {
        public long? CadastroID { get; set; }
        public string CadastroNome { get; set; }
        public string CadastroCPF { get; set; }
        public string CadastroEmail { get; set; }
        public string CadastroTelefone { get; set; }
        public string CadastroEndereco { get; set; }
        public string CadastroMuunicipio { get; set; }
        public string CadastroUF { get; set; }
        public string CadastroCEP { get; set; }

    }
}
