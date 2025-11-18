using PokemonProject.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Entities
{
    public class Game
    {
        public void StartGame()
        {

            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("       POKEMON CONSOLE TOURNAMENT       ");
            Console.WriteLine("=========================");

            Dificulty dificuldade = AskDifficulty();

            PokemonTypes playerType = AskPlayerType();

            Console.Write("Digite o seu nome: ");
            string playerName = Console.ReadLine();
            if (string.IsNullOrEmpty(playerName)) playerName = "Player";


            Pokemon player = new Pokemon (playerName, playerType);
            Console.WriteLine($"\nVocê escolheu o tipo {playerType}! Uma sábia escolha.");
            Console.WriteLine($"Seu HP: {player.HpMax} | Ataque: {player.Fight} | Defesa: {player.Defense}");
            Console.WriteLine("\n>> Pressione qualquer tecla para continuar... <<");
            Console.ReadKey(true);

            List<Pokemon> opponents = GenerateOpponents(playerType, dificuldade);

            int round = 1;
            int totalrounds = opponents.Count;

            foreach(Pokemon enemy in opponents)
            {
                Console.Clear();
                Console.WriteLine($"\n--- ROUND {round} / 4 ---");
                Console.WriteLine($"Prepare-se! Seu Oponente é do tipo {enemy.TypePrincipal}");
                Console.WriteLine("\n>> Pressione qualquer tecla para continuar... <<");
                Console.ReadKey(true);

                Battle battle = new Battle(player, enemy);
                bool playerWon = battle.StartBattle();

                if (playerWon)
                {
                   
                    if (round < totalrounds)    
                    {
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine($"✨ VITÓRIA! Você derrotou {enemy.Name}!");
                        Console.WriteLine("Seu Pokémon descansou e recuperou as energias.");

                        player.LevelUp();

                        Console.WriteLine($"🔼 Status Atualizados: HP Máx {player.HpMax} | Ataque {player.Fight}");
                        Console.WriteLine("Pressione ENTER para o próximo desafio...");
                        Console.WriteLine("----------------------------------------------------");
                        Console.ReadKey(true);
                        round++;
                    }
                    
                }
                else
                {
                  
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("             GAME OVER                  ");
                    Console.WriteLine($"     {player.Name} não pode continuar.   ");
                    Console.WriteLine("========================================");
                    Console.WriteLine("\nPressione ENTER para fechar o jogo...");
                    Console.ReadKey(true);
                    return;
                }


            }

            Console.Clear();
            Console.WriteLine("🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆");
            Console.WriteLine("             PARABÉNS CAMPEÃO!              ");
            Console.WriteLine("       Você venceu o torneio Pokémon!       ");
            Console.WriteLine("🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆");

            Console.WriteLine($"\nCampeão: {player.Name} ({player.TypePrincipal})");
            Console.WriteLine($"HP Final: {player.HpMax} | Ataque Final: {player.Fight}");

            Console.WriteLine("\nObrigado por jogar! Pressione ENTER para sair.");
            Console.ReadKey(true);

        }

        private List<Pokemon> GenerateOpponents(PokemonTypes playerType, Dificulty dificuldade)
        {
            List<Pokemon> enemies = new List<Pokemon>();
            Random rand = new Random();

            List<PokemonTypes> vantajoso = TypesSystem.FindTypesByEffectiveness(playerType, 2.0);
            List<PokemonTypes> neutro = TypesSystem.FindTypesByEffectiveness(playerType, 1.0);
            List<PokemonTypes> perigoso = TypesSystem.FindTypesByEffectiveness(playerType, 0.5);
                
            string[] enemyNames = { "Gary", "Giovanni", "Jesse", "James", "Cynthia", "Brock", "Misty" };

            if (vantajoso.Count == 0) vantajoso = neutro;
            if (perigoso.Count == 0 ) perigoso = neutro;

            List<PokemonTypes> typesSelected = new List<PokemonTypes>();

            switch (dificuldade)
            {
                case Dificulty.Facil:

                    for (int i = 0; i < 4; i++) typesSelected.Add(vantajoso[rand.Next(vantajoso.Count)]);
                    break;

                case Dificulty.Normal:
                    typesSelected.Add(vantajoso[rand.Next(vantajoso.Count)]);
                    typesSelected.Add(vantajoso[rand.Next(vantajoso.Count)]);
                    typesSelected.Add(neutro[rand.Next(neutro.Count)]);
                    typesSelected.Add(perigoso[rand.Next(perigoso.Count)]);
                    break;

                case Dificulty.Dificil:
                    for (int i = 0; i < 4; i++) typesSelected.Add(perigoso[rand.Next(perigoso.Count)]);
                    break;

            }   

            foreach(var type in typesSelected)
            {
                string randomName = enemyNames[rand.Next(enemyNames.Length)];
                enemies.Add(new Pokemon($"{randomName}'s {type}", type));
            }

            return enemies;

        }

        private Dificulty AskDifficulty()
        {
            while (true)
            {

                Console.WriteLine("\n Escolha a dificuldade: ");
                Console.WriteLine("1 - Fácil (Seus ataques serão Super Efetivos)");
                Console.WriteLine("2 - Normal (Equilibrado)");
                Console.WriteLine("3 - Difícil (Seus ataques serão Pouco Efetivos)");
                Console.Write("Opção: ");
                string input = Console.ReadLine();

                if (input == "1") return Dificulty.Facil;
                if (input == "2") return Dificulty.Normal;
                if (input == "3") return Dificulty.Dificil;

                Console.WriteLine("Opção inválida!");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida! Por favor, digite apenas 1, 2 ou 3.");
                Console.ResetColor();

            }
        }

        private PokemonTypes AskPlayerType()
        {
            while (true) 
            {
                Console.WriteLine("\n Escolha o seu Tipo: ");

                var allTypes = Enum.GetValues(typeof(PokemonTypes));

                foreach (var type in allTypes) 
                {
                    Console.WriteLine($"- {type}");
                }

                Console.Write("Digite o nome do tipo (ex: Fire): ");
                string input = Console.ReadLine();

                
                if (Enum.TryParse(input, true, out PokemonTypes result)) 
                {
                    return result;
                }

                Console.WriteLine("Tipo inválido! Tente digitar em inglês (ex: Water, Fire).");

            }
        }

    }
}
