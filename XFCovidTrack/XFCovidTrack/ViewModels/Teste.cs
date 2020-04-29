﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XFCovidTrack.Models;

namespace XFCovidTrack.ViewModels
{
   public class Teste
    {

        public ObservableCollection<Menu> Menu { get; set; }
        public ObservableCollection<PopularFood> popularFoods { get; set; }


        public Teste()
        {

            Menu = new ObservableCollection<Models.Menu>
                {
                    new Menu  {  MenuImage = "Menu1"  },
                    new Menu  {  MenuImage = "Menu2"  },
                    new Menu  {  MenuImage = "Menu3"  },
                    new Menu  {  MenuImage = "Menu4"  },
                    new Menu  {  MenuImage = "Menu5"  },
                    new Menu  {  MenuImage = "Menu6"  }
                };

            popularFoods = new ObservableCollection<PopularFood>
            {
                new PopularFood
                {
                     Image          ="ProfileFood",
                     Description    ="Fresh Chicken Fry",
                     Details        ="Chicken + Vegatables + Oats",
                     FrameColor     ="#28aaab"
                },
                new PopularFood
                {
                     Image          ="Pasta",
                     Description    ="Pasta Pomodoro",
                     Details        ="Chicken + Vegatables + Oats",
                     FrameColor     ="#f13b4f"
                },
                new PopularFood
                {
                     Image          ="Rice",
                     Description    ="Rice Fry",
                     Details        ="Chicken + Vegatables + Oats",
                     FrameColor     ="#fcc041"
                },
                new PopularFood
                {
                     Image          ="ProfileFood",
                     Description    ="Fresh Chicken Fry",
                     Details        ="Chicken + Vegatables + Oats",
                     FrameColor     ="#28aaab"
                }
            };
        }
    }
}
