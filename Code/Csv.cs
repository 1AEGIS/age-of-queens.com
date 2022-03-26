﻿using ageofqueenscom.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace ageofqueenscom.Code
{
    public class Csv
    {
        public static List<IntroductionsViewModel.IntroductionModel> LoadIntroductions()
        {
            string path = "Csv/Introductions.csv";
            using TextFieldParser csvReader = new TextFieldParser(Path.Combine(Directory.GetCurrentDirectory(), path));
            csvReader.CommentTokens = new string[] { "#" };
            csvReader.SetDelimiters(new string[] { "," });

            List< IntroductionsViewModel.IntroductionModel> list = new List< IntroductionsViewModel.IntroductionModel>();
            while (!csvReader.EndOfData)
            {
                IntroductionsViewModel.IntroductionModel item = new  IntroductionsViewModel.IntroductionModel();
                string[] fields = csvReader.ReadFields();
                item.Name = fields[1];
                item.Description = fields[2];
                item.ImageUrl = fields[3];
                item.TwitterUrl = fields[4];
                item.YoutubeUrl = fields[5];
                item.TwitchUrl = fields[6];
                item.InstagramUrl = fields[7];
                list.Add(item);
            }
            return list;
        }
        
        public static List<HomeViewModel.BlogpostModel> LoadBlogposts()
        {
            string path = "Csv/BlogPosts.csv";
            using TextFieldParser csvReader = new TextFieldParser(Path.Combine(Directory.GetCurrentDirectory(), path));
            csvReader.CommentTokens = new string[] { "#" };
            csvReader.SetDelimiters(new string[] { "," });

            List<HomeViewModel.BlogpostModel> blogpostList = new List<HomeViewModel.BlogpostModel>();
            while (!csvReader.EndOfData)
            {
                string[] fields = csvReader.ReadFields();
                HomeViewModel.BlogpostModel blogpost = new HomeViewModel.BlogpostModel
                {
                    Title = fields[0],
                    Content = fields[1],
                    ImageUrl = fields[2],
                    Author = fields[3],
                    Created = fields[4]
                };
                blogpostList.Add(blogpost);
            }
            blogpostList.Reverse(); // So the newest Blogposts are on the top while we still can edit the csv from top to bottom.
            return blogpostList;
        }

        public static List<LeaderboardViewModel.LeaderboardPlayerModel> LoadLeaderboardRM()
        {
            string path = "Csv/LeaderboardRM.csv";
            using TextFieldParser csvReader = new TextFieldParser(Path.Combine(Directory.GetCurrentDirectory(), path));
            csvReader.CommentTokens = new string[] { "#" };
            csvReader.SetDelimiters(new string[] { "," });

            List<LeaderboardViewModel.LeaderboardPlayerModel> playerList = new List<LeaderboardViewModel.LeaderboardPlayerModel>();
            csvReader.ReadLine();   // We don't have write access to the file so we need to skip lines which are not commented
            csvReader.ReadLine();
            csvReader.ReadLine();
            csvReader.ReadLine();
            csvReader.ReadLine();
            csvReader.ReadLine();
            csvReader.ReadLine();
            while (!csvReader.EndOfData)
            {
                string[] fields = csvReader.ReadFields();
                LeaderboardViewModel.LeaderboardPlayerModel player = new LeaderboardViewModel.LeaderboardPlayerModel();
                if (String.IsNullOrEmpty(fields[1])) break; // We don't have write access to the file and many lines are not filled but still there
                player.Name = fields[1];
                player.Country = fields[2];
                player.Id = int.Parse(fields[3]);
                player.Rating = int.Parse(fields[5]);
                player.HighestRating = int.Parse(fields[6]);
                playerList.Add(player);
            }
            return playerList;
        }

        public static List<ModsViewModel.ModModel> LoadMods()
        {
            string path = "Csv/Mods.csv";
            using TextFieldParser csvReader = new TextFieldParser(Path.Combine(Directory.GetCurrentDirectory(), path));
            csvReader.CommentTokens = new string[] { "#" };
            csvReader.SetDelimiters(new string[] { "," });

            List<ModsViewModel.ModModel> modList = new List<ModsViewModel.ModModel>();
            while (!csvReader.EndOfData)
            {
                string[] fields = csvReader.ReadFields();
                ModsViewModel.ModModel mod = new ModsViewModel.ModModel
                {
                    Title = fields[0],
                    Description = fields[1],
                    Creator = fields[2],
                    Date = fields[3],
                    Id = fields[4],
                    Category = fields[5],
                    ImageUrl = fields[6],
                    ModUrl = "https://www.ageofempires.com/mods/details/" + fields[4]
                };
                modList.Add(mod);
            }
            return modList;
        }

        public static ActiveEventViewModel LoadActiveEvent(){
            string path = "Csv/Current_Event_Data.csv";
            using TextFieldParser csvReader = new TextFieldParser(Path.Combine(Directory.GetCurrentDirectory(), path));
            csvReader.CommentTokens = new string[] { "#" };
            csvReader.SetDelimiters(new string[] { "," });

            ActiveEventViewModel model = new ActiveEventViewModel();
            model.ActiveGameEventGameList = new List<ActiveEventViewModel.ActiveEventGameModel>();                
            
            // Sets the meta data for the model.
            string[] fields = csvReader.ReadFields();
            model.Title = fields[0];
            model.Information = fields[1];
            model.RegistrationLink = fields[2];
            model.Image = fields[3];
            
            // Reads every game in the event and pushes it into a list in the model.
            while (!csvReader.EndOfData)
            {
                fields = csvReader.ReadFields();
                ActiveEventViewModel.ActiveEventGameModel gameModel = new ActiveEventViewModel.ActiveEventGameModel(){
                    Date = fields[0],
                    ActiveEventTeams = new List<string>(),
                    Maps = fields[9],
                    Mode = fields[10],
                    Information = fields[11]
                };
                // Adds the teams. We can have 8 teams max.
                for(int i = 1; i < 9; i++){
                    if(!String.IsNullOrEmpty(fields[i])) gameModel.ActiveEventTeams.Add(fields[i]);
                }
                model.ActiveGameEventGameList.Add(gameModel);
            }
            return model;
        }
    }
}
