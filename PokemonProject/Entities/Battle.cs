using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Entities
{
    public class Battle
    {
        private Pokemon _Player;
        private Pokemon _Enemy;

        public Battle(Pokemon player, Pokemon enemy)
        {
            _Player = player;
            _Enemy = enemy;
        }

        public bool StartBattle()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine($"⚔️  {_Player.Name} ({_Player.TypePrincipal}) VS {_Enemy.Name} ({_Enemy.TypePrincipal})  ⚔️");
            Console.WriteLine("=========================================");

            while (_Player.EstaVivo() && _Enemy.EstaVivo())
            {
                Console.WriteLine($"\nStatus {_Player.Name}: {_Player.HpNow}/{_Player.HpMax} HP");
                Console.WriteLine($"Status {_Enemy.Name}: {_Enemy.HpNow}/{_Enemy.HpMax} HP");

 
                Console.WriteLine("\nSua vez! Escolha uma ação:");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defender (Reduz dano recebido)");
                Console.Write("Opção: ");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char option = keyInfo.KeyChar; 

                bool isPlayerDefending = false;

                if (option == '1')
                {
                    Console.WriteLine("1"); 
                    ExecuteAttack(_Player, _Enemy, false);
                }
                else if (option == '2')
                {
                    Console.WriteLine("2"); 
                    Console.WriteLine($"\n🛡️ {_Player.Name} entrou em posição de defesa!");
                    isPlayerDefending = true;
                }
                else
                {
                   
                    Console.WriteLine("\n❌ Tecla inválida! Use apenas 1 ou 2.");
                    continue; 
                }



                
                Console.WriteLine($"\n >>> Vez de {_Enemy.Name} <<<");
                ExecuteAttack(_Enemy, _Player, isPlayerDefending);

                
                if (!_Player.EstaVivo())
                {
                    Console.WriteLine($"\n💀 {_Player.Name} desmaiou... VOCÊ PERDEU.");
                    Console.ReadLine();
                    return false; 
                }

                Console.WriteLine("-----------------------------------------");
            }

            
            return _Player.EstaVivo();
        }

        private void ExecuteAttack(Pokemon attacker, Pokemon defender, bool IsDefenderGuarding)
        {
            Console.WriteLine(attacker.GetDescriptionAttack());

            int attackPower = attacker.Fight;
            int enemyDefense = defender.Defense;

            double multiplier = TypesSystem.AttackMultiple(attacker.TypePrincipal, defender.TypePrincipal);

            int damage = (int)((attackPower * 10.0) / enemyDefense * multiplier);


            if (IsDefenderGuarding) 
            {
                Console.WriteLine("🛡️ O dano foi reduzido pela defesa!");
                damage = damage / 2;
            }

            if (damage <= 0) damage = 1;

            defender.ReceiveDamage(damage);

            if (multiplier > 1.0) Console.WriteLine("🔥 FOI SUPER EFETIVO!");
            else if (multiplier < 1.0 && multiplier > 0.0) Console.WriteLine("🛡️ Não foi muito efetivo...");
            else if (multiplier == 0.0) Console.WriteLine("👻 Não afetou o oponente...");

            Console.WriteLine($"Dano Causado: {damage}");
            Console.WriteLine($"HP do {defender.TypePrincipal}: {defender.HpNow} / {defender.HpMax}");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine(">> Pressione qualquer tecla para continuar... <<");
            Console.ReadKey(true); 
        }


    }
}
