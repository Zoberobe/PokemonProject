using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonProject.Entities.Enums;

namespace PokemonProject.Entities
{
    public class Pokemon
    {
        public PokemonTypes TypePrincipal {  get; private set; }
        public int HpMax { get; private set; }
        public int HpNow { get; set; }
        public int Defense { get; private set; }
        public int Fight { get; private set; }

        public string Name { get; private set; }

        public Pokemon(String nome, PokemonTypes TipoPokemon)
        {
            this.Name = nome;
            this.TypePrincipal = TipoPokemon;

            (int HpMax, int Defense, int Fight) stats = this.TypePrincipal switch
            {
                PokemonTypes.Fire => (115, 120, 115),
                PokemonTypes.Grass => (114, 131, 109),
                PokemonTypes.Water => (165,180,110),
                PokemonTypes.Normal =>(160,110,140),
                PokemonTypes.Electric => (110, 115, 123),
                PokemonTypes.Ice => (130,180,130),
                PokemonTypes.Fighting => (144, 125, 140),
                PokemonTypes.Poison => (105, 152, 105),
                PokemonTypes.Ground => (115,130,140),
                PokemonTypes.Flying => (105,130,134),
                PokemonTypes.Psychic => (120,130,125),
                PokemonTypes.Bug => (107, 140, 120),
                PokemonTypes.Rock => (115, 200, 134),
                PokemonTypes.Ghost => (150,120,124),
                PokemonTypes.Dragon => (153,125,150),
                PokemonTypes.Dark => (126,110,120),
                PokemonTypes.Steel => (130,180,170),
                PokemonTypes.Fairy => (105,150,120)
            };

            this.HpMax = stats.HpMax;
            this.Defense = stats.Defense;
            this.Fight = stats.Fight;
            this.HpNow = this.HpMax;

        }

        public string GetDescriptionAttack()
        {

            return this.TypePrincipal switch
            {
                PokemonTypes.Fire => "O Pokémon atacou com uma rajada de FOGO!",
                PokemonTypes.Grass => "O Pokémon atacou com o poder da GRAMA!",
                PokemonTypes.Water => "O Pokémon atacou com um jato de ÁGUA!",
                PokemonTypes.Normal => "O Pokémon usou um ataque NORMAL!",
                PokemonTypes.Electric => "O Pokémon atacou com um choque ELÉTRICO!",
                PokemonTypes.Ice => "O Pokémon atacou com uma rajada de GELO!",
                PokemonTypes.Fighting => "O Pokémon usou um golpe de LUTA!",
                PokemonTypes.Poison => "O Pokémon atacou com VENENO!",
                PokemonTypes.Ground => "O Pokémon atacou com o poder da TERRA!",
                PokemonTypes.Flying => "O Pokémon atacou com uma rajada de VENTO!",
                PokemonTypes.Psychic => "O Pokémon usou um ataque PSÍQUICO!",
                PokemonTypes.Bug => "O Pokémon atacou com o poder dos INSETOS!",
                PokemonTypes.Rock => "O Pokémon atacou com uma avalanche de PEDRAS!",
                PokemonTypes.Ghost => "O Pokémon usou um ataque FANTASMA!",
                PokemonTypes.Dragon => "O Pokémon usou a fúria do DRAGÃO!",
                PokemonTypes.Dark => "O Pokémon usou um golpe SOMBRIO!",
                PokemonTypes.Steel => "O Pokémon atacou com o poder do AÇO!",
                PokemonTypes.Fairy => "O Pokémon usou o poder das FADAS!"
            };
                
        }

        public void ReceiveDamage (int damage)
        {
            this.HpNow -= damage;

            if(this.HpNow < 0)
            {
                this.HpNow = 0;
            }
        }

        public bool EstaVivo()
        {
            return this.HpNow > 0;
        }

        public void LevelUp()
        {
            this.HpMax = (int)(this.HpMax * 1.10);
            this.Fight = (int)(this.Fight * 1.10);

            this.HpNow = this.HpMax;
        }

    }
}
