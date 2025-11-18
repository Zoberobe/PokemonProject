using System;
using PokemonProject.Entities;

namespace PokemonProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Cria a instância do jogo
            Game game = new Game();

            // Inicia o jogo
            game.StartGame();
        }
    }
}