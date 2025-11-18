using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonProject.Entities.Enums;

namespace PokemonProject.Entities
{
    public static class TypesSystem
    {
        private static readonly Dictionary<(PokemonTypes, PokemonTypes), double> _effectivenessmap;

        static TypesSystem()
        {
            _effectivenessmap = new Dictionary<(PokemonTypes, PokemonTypes), double>

            {
                //Regras Fogo
                {(PokemonTypes.Fire, PokemonTypes.Grass), 2.0 },
                {(PokemonTypes.Fire, PokemonTypes.Ice), 2.0 },
                {(PokemonTypes.Fire, PokemonTypes.Bug), 2.0 },
                {(PokemonTypes.Fire, PokemonTypes.Steel), 2.0 },
                //---------------------------------------------
                {(PokemonTypes.Fire, PokemonTypes.Fire), 0.5 },
                {(PokemonTypes.Fire, PokemonTypes.Water), 0.5 },
                {(PokemonTypes.Fire, PokemonTypes.Rock), 0.5 },
                {(PokemonTypes.Fire, PokemonTypes.Dragon), 0.5 },

                //Regras Gelo
                {(PokemonTypes.Ice, PokemonTypes.Grass), 2.0 },
                {(PokemonTypes.Ice, PokemonTypes.Ground), 2.0 },
                {(PokemonTypes.Ice, PokemonTypes.Flying), 2.0 },
                {(PokemonTypes.Ice, PokemonTypes.Dragon), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Ice, PokemonTypes.Fire), 0.5 },
                {(PokemonTypes.Ice, PokemonTypes.Water), 0.5 },
                {(PokemonTypes.Ice, PokemonTypes.Ice), 0.5 },
                {(PokemonTypes.Ice, PokemonTypes.Steel), 0.5 },

                //Regras Grama
                {(PokemonTypes.Grass, PokemonTypes.Water), 2.0 },
                {(PokemonTypes.Grass, PokemonTypes.Ground), 2.0 },
                {(PokemonTypes.Grass, PokemonTypes.Rock), 2.0 },
                //---------------------------------------------
                {(PokemonTypes.Grass, PokemonTypes.Fire), 0.5 },
                {(PokemonTypes.Grass, PokemonTypes.Grass), 0.5 },
                {(PokemonTypes.Grass, PokemonTypes.Poison), 0.5 },
                {(PokemonTypes.Grass, PokemonTypes.Flying), 0.5 },
                {(PokemonTypes.Grass, PokemonTypes.Bug), 0.5 },
                {(PokemonTypes.Grass, PokemonTypes.Dragon), 0.5 },
                {(PokemonTypes.Grass, PokemonTypes.Steel), 0.5 },

                //Regras Agua
                {(PokemonTypes.Water, PokemonTypes.Fire), 2.0 },
                {(PokemonTypes.Water, PokemonTypes.Ground), 2.0 },
                {(PokemonTypes.Water, PokemonTypes.Rock), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Water, PokemonTypes.Water), 0.5 },
                {(PokemonTypes.Water, PokemonTypes.Grass), 0.5 },
                {(PokemonTypes.Water, PokemonTypes.Dragon), 0.5 },

                //Regras Aço
                {(PokemonTypes.Steel, PokemonTypes.Ice), 2.0 },
                {(PokemonTypes.Steel, PokemonTypes.Rock), 2.0 },
                {(PokemonTypes.Steel, PokemonTypes.Fairy), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Steel, PokemonTypes.Steel), 0.5 },
                {(PokemonTypes.Steel, PokemonTypes.Fire), 0.5 },
                {(PokemonTypes.Steel, PokemonTypes.Water), 0.5 },
                {(PokemonTypes.Steel, PokemonTypes.Electric), 0.5 },

                //Regras Dragao
                {(PokemonTypes.Dragon, PokemonTypes.Dragon), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Dragon, PokemonTypes.Steel), 0.5 },

                //Regras Elétrico
                {(PokemonTypes.Electric, PokemonTypes.Water), 2.0 },
                {(PokemonTypes.Electric, PokemonTypes.Flying), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Electric, PokemonTypes.Electric), 0.5 },
                {(PokemonTypes.Electric, PokemonTypes.Grass), 0.5 },
                {(PokemonTypes.Electric, PokemonTypes.Dragon), 0.5 },

                //Regras Fada
                {(PokemonTypes.Fairy, PokemonTypes.Fighting), 2.0 },
                {(PokemonTypes.Fairy, PokemonTypes.Dragon), 2.0 },
                {(PokemonTypes.Fairy, PokemonTypes.Dark), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Fairy, PokemonTypes.Fire), 0.5 },
                {(PokemonTypes.Fairy, PokemonTypes.Poison), 0.5 },
                {(PokemonTypes.Fairy, PokemonTypes.Steel), 0.5 },

                //Regras Fantasma
                {(PokemonTypes.Ghost, PokemonTypes.Ghost), 2.0 },
                {(PokemonTypes.Ghost, PokemonTypes.Psychic), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Ghost, PokemonTypes.Dark), 0.5 },

                //Regras Lutador
                {(PokemonTypes.Fighting, PokemonTypes.Normal), 2.0 },
                {(PokemonTypes.Fighting, PokemonTypes.Ice), 2.0 },
                {(PokemonTypes.Fighting, PokemonTypes.Rock), 2.0 },
                {(PokemonTypes.Fighting, PokemonTypes.Dark), 2.0 },
                {(PokemonTypes.Fighting, PokemonTypes.Steel), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Fighting, PokemonTypes.Poison), 0.5 },
                {(PokemonTypes.Fighting, PokemonTypes.Flying), 0.5 },
                {(PokemonTypes.Fighting, PokemonTypes.Psychic), 0.5 },
                {(PokemonTypes.Fighting, PokemonTypes.Bug), 0.5 },
                {(PokemonTypes.Fighting, PokemonTypes.Fairy), 0.5 },

                //Regras Normal
                {(PokemonTypes.Normal, PokemonTypes.Rock), 0.5 },
                {(PokemonTypes.Normal, PokemonTypes.Steel), 0.5 },
                //----------------------------------------------

                //Regras Pedra
                {(PokemonTypes.Rock, PokemonTypes.Fire), 2.0 },
                {(PokemonTypes.Rock, PokemonTypes.Ice), 2.0 },
                {(PokemonTypes.Rock, PokemonTypes.Flying), 2.0 },
                {(PokemonTypes.Rock, PokemonTypes.Bug), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Rock, PokemonTypes.Fighting), 0.5 },
                {(PokemonTypes.Rock, PokemonTypes.Ground), 0.5 },
                {(PokemonTypes.Rock, PokemonTypes.Steel), 0.5 },

                //Regras Psiquico
                {(PokemonTypes.Psychic, PokemonTypes.Fighting), 2.0 },
                {(PokemonTypes.Psychic, PokemonTypes.Poison), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Psychic, PokemonTypes.Psychic), 0.5 },
                {(PokemonTypes.Psychic, PokemonTypes.Steel), 0.5 },

                //Regras Sombrio
                {(PokemonTypes.Dark, PokemonTypes.Ghost), 2.0 },
                {(PokemonTypes.Dark, PokemonTypes.Psychic), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Dark, PokemonTypes.Fighting), 0.5 },
                {(PokemonTypes.Dark, PokemonTypes.Dark), 0.5 },
                {(PokemonTypes.Dark, PokemonTypes.Fairy), 0.5 },

                //Regras Terrestre
                {(PokemonTypes.Ground, PokemonTypes.Fire), 2.0 },
                {(PokemonTypes.Ground, PokemonTypes.Electric), 2.0 },
                {(PokemonTypes.Ground, PokemonTypes.Poison), 2.0 },
                {(PokemonTypes.Ground, PokemonTypes.Rock), 2.0 },
                {(PokemonTypes.Ground, PokemonTypes.Steel), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Ground, PokemonTypes.Bug), 0.5 },
                {(PokemonTypes.Ground, PokemonTypes.Grass), 0.5 },

                //Regras Veneno
                {(PokemonTypes.Poison, PokemonTypes.Grass), 2.0 },
                {(PokemonTypes.Poison, PokemonTypes.Fairy), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Poison, PokemonTypes.Poison), 0.5 },
                {(PokemonTypes.Poison, PokemonTypes.Ground), 0.5 },
                {(PokemonTypes.Poison, PokemonTypes.Rock), 0.5 },
                {(PokemonTypes.Poison, PokemonTypes.Ghost), 0.5 },

                //Regras Voador
                {(PokemonTypes.Flying, PokemonTypes.Grass), 2.0 },
                {(PokemonTypes.Flying, PokemonTypes.Fighting), 2.0 },
                {(PokemonTypes.Flying, PokemonTypes.Bug), 2.0 },
                //----------------------------------------------
                {(PokemonTypes.Flying, PokemonTypes.Electric), 0.5 },
                {(PokemonTypes.Flying, PokemonTypes.Rock), 0.5 },
                {(PokemonTypes.Flying, PokemonTypes.Steel), 0.5 },

            };
        }

        public static double AttackMultiple(PokemonTypes TipoPokemonAtaque, PokemonTypes TipoPokemonDefensor)
        {
            var key = (TipoPokemonAtaque, TipoPokemonDefensor);

            if(_effectivenessmap.TryGetValue(key, out double multiplicador)){
                return multiplicador;
            }
            return 1.0;
        }

        public static List<PokemonTypes> FindTypesByEffectiveness(PokemonTypes TipoPokemonAtaque, double efetividadeDesejada)
        {
            var TypesFinded = new List<PokemonTypes>();
            foreach (PokemonTypes TipoPokemonDefensor in Enum.GetValues(typeof(PokemonTypes)))
            {
                double multiplicado = AttackMultiple(TipoPokemonAtaque, TipoPokemonDefensor);
                if (multiplicado == efetividadeDesejada)
                {
                    TypesFinded.Add(TipoPokemonDefensor);

                }
            }

            return TypesFinded;
        } 


    }
}
