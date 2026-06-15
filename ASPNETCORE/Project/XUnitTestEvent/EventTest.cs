using System;
using WebApplication.Entities;
using Xunit;

namespace XUnitTestEvent
{
    public class EventTest
    {
        [Fact]
        public void deveAceitarTagCorreta()
        {
            // arrange
            string tag = "brasil.nordeste.sensor03";
            Event evento = criarEventoSetandoTag(tag);

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 1, $"{tag} deveria ser válido");
        }

        [Theory]
        [InlineData("")]
        [InlineData("brasil.casa.teste.sudeste")]
        [InlineData("brasil.sensor")]
        [InlineData("sensor12")]
        public void deveTagConter3valores(string tag)
        {
            // arrange
            Event evento = criarEventoSetandoTag(tag);

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 0, $"{tag} deveria ser inválido");
        }

        [Theory]
        [InlineData("colombia.nordeste.sensor03")]
        [InlineData("Brasil.nordeste.sensor03")] // Este caso está errado pois "Brasil" tem primeira letra maiuscula
        public void primeiroValorTagDeveSerbrasil(string tag)
        {
            // arrange
            Event evento = criarEventoSetandoTag(tag);

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 0, $"{tag} deveria ser inválido");
        }

        [Theory]
        [InlineData("brasil.norte.sensor01")]
        [InlineData("brasil.nordeste.sensor01")]
        [InlineData("brasil.sul.sensor01")]
        [InlineData("brasil.sudeste.sensor01")]
        [InlineData("brasil.centrooeste.sensor01")]
        public void segundoValorTagDeveSer5Regioes(string tag)
        {
            // arrange
            Event evento = criarEventoSetandoTag(tag);

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 1, $"{tag} deveria ser válido");
        }

        [Theory]
        [InlineData("brasil.noroeste.sensor01")]
        [InlineData("brasil.centrosul.sensor01")]
        public void segundoValorTagNaoDeveAceitarRegiaoErrada(string tag)
        {
            // arrange
            Event evento = criarEventoSetandoTag(tag);

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 0, $"{tag} deveria ser inválido");
        }

        [Theory]
        [InlineData("brasil.sudeste.")]
        [InlineData("brasil.sudeste")]
        public void terceiroValorTagNaoDeveSerVazio(string tag)
        {
            // arrange
            Event evento = criarEventoSetandoTag(tag);

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 0, $"{tag} deveria ser inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void valorNaoDeveEstarVazio(string valor)
        {
            // arrange
            Event evento = new Event();
            evento.tag = "brasil.centrooeste.sensor01";
            evento.timestamp = "1608581543";
            evento.valor = valor;

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 0, $"{valor} deveria ser inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void dataNaoDeveEstarVazia(string timestamp)
        {
            // arrange
            Event evento = new Event();
            evento.tag = "brasil.centrooeste.sensor01";
            evento.timestamp = timestamp;
            evento.valor = "11";

            // act
            evento.setarPaisRegiaoSensor();

            // assert
            Assert.True(evento.valido == 0, $"{timestamp} deveria ser inválido");
        }

        private Event criarEventoSetandoTag(string tag)
        {
            Event evento = new Event();
            evento.tag = tag;
            evento.timestamp = "1608581543";
            evento.valor = "11";

            return evento;
        }
    }
}
