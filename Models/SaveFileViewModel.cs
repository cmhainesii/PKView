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
    public string TimeResetCode { get; set; }

    public List<PokemonViewModel> _partyPokemon;

    public SaveFileViewModel(GameData saveData)
    {
        Trainer trainer = saveData.Trainer;
        TrainerName = trainer.Name;
        TrainerId = trainer.Id;
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
        TimeResetCode = saveData.TimeResetPassword;

        _partyPokemon = new List<PokemonViewModel>();
        foreach (Pokemon pokemon in saveData.PartyPokemon.GetParty())
        {
            _partyPokemon.Add(new PokemonViewModel(pokemon));
        }

    }


}
