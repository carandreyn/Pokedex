using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Pokedex
{
    public partial class PokedexSearch : Form
    {
        public PokedexSearch()
        {
            InitializeComponent();
        }

        private void SearchPokemonButton_Click(object sender, EventArgs e)
        {
            getPokemonInfo();
            getPokemonSpeciesInfo();
            getPokemonDescription();
        }

        private void getPokemonInfo()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    if (TBPokemon.Text == "")
                    {
                        TBPokemon.Text = "mewtwo";
                        MessageBox.Show("A Mewtwo Appeared!");
                    }

                    string url = $"https://pokeapi.co/api/v2/pokemon/{TBPokemon.Text.ToLower()}";
                    var json = client.DownloadString(url);
                    PokemonInfo.root Info = JsonConvert.DeserializeObject<PokemonInfo.root>(json);

                    // Get Name from API
                    string pokemonName = Info.Name;
                    LblPokemonName.Text = pokemonName[0].ToString().ToUpper() + pokemonName.Substring(1).ToLower();

                    // Get ID from API
                    LblPokemonID.Text = Info.ID.ToString("000");

                    // Get Pokemon Height from API
                    int height = Info.Height;
                    LblHeight.Text = Math.Round((double)Info.Height / 10, 2).ToString() + " m";

                    // Get Pokemon Weight from API
                    LblWeight.Text = (Info.Weight * 0.1).ToString("0.0") + " kg";

                    // Get Pokemon Picture URL and display in PictureBox
                    JObject pictures = (JObject)Info.Sprites;
                    string pictureURL = (string)pictures["front_default"];
                    PokemonPic.Load(pictureURL);
                    PokemonPic.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Get Pokemon Type from API
                    JObject type = (JObject)Info.Types[0].Type;
                    string pokemonType = (string)type["name"];
                    LblType.Text = pokemonType[0].ToString().ToUpper() + pokemonType.Substring(1).ToLower();

                    // Get Pokemon Ability from API
                    JObject ability = (JObject)Info.abilities[0].Ability;
                    string pokemonAbility = (string)ability["name"];
                    LblAbility.Text = pokemonAbility[0].ToString().ToUpper() + pokemonAbility.Substring(1).ToLower();

                    // Get HP for Progress Bar and Label
                    int HP = Info.stats[0].Base_Stat;
                    HPProgressBar.Value = HP;
                    LblHP.Text = HP.ToString();

                    // Get Attack for Progress Bar and Label
                    int Attack = Info.stats[1].Base_Stat;
                    AttackProgressBar.Value = Attack;
                    LblAttack.Text = Attack.ToString();

                    // Get Defense for Progress Bar and Label
                    int Defense = Info.stats[2].Base_Stat;
                    DefenseProgressBar.Value = Defense;
                    LblDefense.Text = Defense.ToString();

                    // Get Special Attack for Progress Bar and Label
                    int SpecialAttack = Info.stats[3].Base_Stat;
                    SAttackProgressBar.Value = SpecialAttack;
                    LblSpecAttack.Text = SpecialAttack.ToString();

                    // Get Special Defense for Progress Bar and Label
                    int SpecialDefense = Info.stats[4].Base_Stat;
                    SDefenseProgressBar.Value = SpecialDefense;
                    LblSpecDefense.Text = SpecialDefense.ToString();

                    // Get Speed for Progress Bar and Label
                    int Speed = Info.stats[5].Base_Stat;
                    SpeedProgressBar.Value = Speed;
                    LblSpeed.Text = Speed.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getPokemonSpeciesInfo()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    if (TBPokemon.Text == "")
                    {
                        TBPokemon.Text = "mewtwo";
                        MessageBox.Show("A Mewtwo Appeared!");
                    }

                    string url = $"https://pokeapi.co/api/v2/pokemon-species/{TBPokemon.Text.ToLower()}";
                    var json = client.DownloadString(url);
                    PokemonSpeciesInfo.root Info = JsonConvert.DeserializeObject<PokemonSpeciesInfo.root>(json);

                    // Change color of picturebox background
                    JObject colors = (JObject)Info.Color;
                    string color = colors["name"].ToString();
                    PokemonPic.BackColor = (Color)new ColorConverter().ConvertFromString(color);

                    // Get Base Happiness for Progress Bar and Label
                    int base_happiness = Info.Base_Happiness;
                    BaseHappinessProgressBar.Value = base_happiness;
                    LblBaseHappiness.Text = base_happiness.ToString();

                    // Get Capture Rate for Progress bar and Label
                    int capture_rate = Info.Capture_Rate;
                    CaptureRateProgressBar.Value = capture_rate;
                    LblCaptureRate.Text = capture_rate.ToString();

                    // Get generation from API
                    JObject generations = (JObject)Info.Generation;
                    LblGeneration.Text = generations["name"].ToString().Replace('-', ' ').ToUpper();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getPokemonDescription()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    if (TBPokemon.Text == "")
                    {
                        TBPokemon.Text = "mewtwo";
                        MessageBox.Show("A Mewtwo Appeared!");
                    }

                    string url = $"https://courses.cs.washington.edu/courses/cse154/webservices/pokedex/pokedex.php?pokemon={TBPokemon.Text.ToLower()}";
                    var json = client.DownloadString(url);
                    PokemonDescriptionInfo.root Info = JsonConvert.DeserializeObject<PokemonDescriptionInfo.root>(json);

                    // Get description from API
                    JObject descriptions = (JObject)Info.Info;
                    string description = descriptions["description"].ToString();
                    LblDescription.Text = description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LblDescription.Text = "";
            }
        }
    }
}
