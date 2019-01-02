using DataBaseAPI.Data.Entities.Context;
using DataBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.DataAccess.Seeder
{
    public static class UnicornSeeder
    {

        public static void SeedUnicorns(this UnicornContext context)
        {
            context.Database.EnsureCreated();

            context.Unicorns.RemoveRange(context.Unicorns);
            context.HornTypes.RemoveRange(context.HornTypes);
            context.SaveChanges();

            Guid hornOne = Guid.NewGuid();
            Guid hornTwo = Guid.NewGuid();
            Guid hornThree = Guid.NewGuid();

            List<HornType> hornTypes = new List<HornType>() {
                new HornType(){
                    Id = hornOne,
                    Type = "Super glitter enhanced",
                    Material="Gold",
                    Decoration = "Extra polished"
                },
                 new HornType(){
                     Id = hornTwo,
                    Type = "Feather crystal",
                    Material="Pixiewing membran",
                    Decoration = "ruby dust"
                },
                new HornType(){
                    Id = hornThree,
                    Type = "Rainbow shine",
                    Material="Rainbow essence",
                    Decoration = "Twisted crystal raindrops"
                }
            };

            context.HornTypes.AddRange(hornTypes);
            context.SaveChanges();


            List<Unicorn> unicorns = new List<Unicorn>()
            {
                new Unicorn(){
                   Id = Guid.NewGuid(),
                    Name = "StarShine",
                    Breed ="Full moonlight",
                    DateOfBirth =  new DateTime(1535,12,12),
                    Description ="Runs faster the light when the moon is full",


                    HornType =   new HornType(){
                    Id = hornOne,
                    Type = "Super glitter enhanced",
                    Material="Gold",
                    Decoration = "Extra polished"
                },

                    IsDeleted = false,
                    IsSold = false,
                    Origin = "Sweden"
                },
                 new Unicorn(){
                    Id = Guid.NewGuid(),
                    Name = "Glitter Posh",
                    Breed ="Equilibrium streak",
                    DateOfBirth =  new DateTime(1535,12,12),
                    Description ="Strong as ten oxes",

                    HornType =   new HornType(){
                    Id = hornOne,
                    Type = "Super glitter enhanced",
                    Material="Gold",
                    Decoration = "Extra polished"
                },

                    IsDeleted = false,
                    IsSold = false,
                    Origin = "Poland highlands"
                },
                  new Unicorn(){
                    Id = Guid.NewGuid(),
                    Name = "Juju-bebe",
                    Breed ="Full metal core",
                    DateOfBirth =  new DateTime(1952,06,06),
                    Description ="Conjures illusions",

                    HornType =   new HornType(){
                     Id = hornTwo,
                    Type = "Feather crystal",
                    Material="Pixiewing membran",
                    Decoration = "ruby dust"
                },

                    IsDeleted = false,
                    IsSold = false,
                    Origin = "Backside of the moon"
                },
                   new Unicorn(){
                    Id = Guid.NewGuid(),
                    Name = "Glow spark",
                    Breed ="Twitch Sunlight",
                    DateOfBirth =  new DateTime(1855,10,12),
                    Description ="Teleports to a destination in its mind",

                    HornType =   new HornType(){
                     Id = hornTwo,
                    Type = "Feather crystal",
                    Material="Pixiewing membran",
                    Decoration = "ruby dust"
                },

                    IsDeleted = false,
                    IsSold = false,
                    Origin = "Lubeck"
                },
                    new Unicorn(){
                           Id = Guid.NewGuid(),
                    Name = "Grand master Beef",
                    Breed ="Amazing Rich",
                    DateOfBirth =  new DateTime(1535,12,12),
                    Description ="Stonges among Unicorns on all fronts. Mimics other unicorn abilities.",

                    HornType =     new HornType(){
                    Id = hornThree,
                    Type = "Rainbow shine",
                    Material="Rainbow essence",
                    Decoration = "Twisted crystal raindrops"
                },

                    IsDeleted = false,
                    IsSold = false,
                    Origin = "Canada"
                },

            };

            context.Unicorns.AddRange(unicorns);
            context.SaveChanges();
        }


    }
}
