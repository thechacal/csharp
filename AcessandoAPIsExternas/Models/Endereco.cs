namespace AcessandoAPIsExternas.Models
{
    public class Endereco
    {
        // Propriedades de um endereço
        public string? Cep { get; set; } // CEP do endereço
        public string? TipoLogradouro { get; set; } // Tipo de logradouro
        public string? Logradouro { get; set; } // Nome do logradouro
        public string? Bairro { get; set; } // Bairro do endereço
        public string? Localidade { get; set; } // Cidade do endereço
        public string? Uf { get; set; } // Unidade Federativa (Estado)
        public string? NumeroLocalidade { get; set; } // Número da localidade
        public string? NomeLogradouro { get; set; } // Nome do logradouro completo
        public string? Complemento { get; set; } // Complemento do endereço
        public string? Abreviatura { get; set; } // Abreviatura do logradouro
        public string? NomeMunicipio { get; set; } // Nome do município
        public string? LocalidadeSuperior { get; set; } // Localidade superior
        public string? TipoCEP { get; set; } // Tipo de CEP
        public string? CepUnidadeOperacional { get; set; } // CEP da unidade operacional
        public string? Lado { get; set; } // Lado da rua
        public string? NumeroInicial { get; set; } // Número inicial do logradouro
        public string? NumeroFinal { get; set; } // Número final do logradouro
    }
}
