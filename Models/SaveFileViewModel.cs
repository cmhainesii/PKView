using System;
using PKLib;

namespace PKView.Models;

public class SaveFileViewModel
{

    public string TrainerName { get; set; }
    public string TrainerId { get; set; }
    public int Money { get; set; }
    public int BadgeCount { get; set; }
    public int SeenCount { get; set; }
    public int CaughtCount { get; set; }
    public int Generation { get; set; }
    public string RivalName { get; set; }
    public string TimeResetCode { get; set; } = "00000";

    public List<PokemonViewModel> _partyPokemon;

    public SaveFileViewModel(GameData saveData)
    {
        TrainerName = saveData.GetTrainerName();
        TrainerId = saveData.GetTrainerID();
        Money = (int)saveData.GetMoney();
        SeenCount = saveData.GetNumberSeen();
        CaughtCount = saveData.GetNumberOwned();
        Generation = saveData.GetGeneration();
        RivalName = saveData.GetRivalName();
        BadgeCount = saveData.GetBadges().GetNumBadges();
        if (Generation == 2)
        {
            TimeResetCode = PokemonUtil.GCSTimeResetPassword(
                TrainerName,
                int.Parse(TrainerId),
                Money
            );
        }

        _partyPokemon = new List<PokemonViewModel>();
        foreach (Pokemon pokemon in saveData.GetPartyPokemon())
        {
            _partyPokemon.Add(new PokemonViewModel(pokemon));
        }

    }


}
