﻿using System;
using System.Collections.Generic;
using System.Linq;
using Franchise.Data.Models;

namespace Franchise.Data.Databases
{
    public class DictControl
    {

        public static IDictionary<int, LocationModel> GlobalDict { get; set; }

        public static IDictionary<int, LocationModel> CreateDict(string csvFile)
        {
            List<LocationModel> models = ParserControl.GetAllLocations(csvFile);

            IDictionary<int, LocationModel> dict = new Dictionary<int, LocationModel>();

            foreach (LocationModel model in models)
            {
                //starting dictionary key at 0 for distance matrix
                dict.Add((Int32.Parse(model.Id.ToString())) - 1, model);
            }
            return dict;
        }

        //CREATE
        public static IDictionary<int, LocationModel> AddLocation(IDictionary<int, LocationModel> dict, long longitude, long latitude, string name)
        {
            var maxKey = dict.Keys.Max();

            var loc = new LocationModel
            {
                Id = maxKey + 1,
                Name = name,
                GeoPoint = new GeoCoordinatePortable.GeoCoordinate(latitude, longitude)
            };

            dict.Add(maxKey + 1, loc);

            return dict;
        }

        //READ
        public static LocationModel ViewLocation(IDictionary<int, LocationModel> dict, int id)
        {
            var tempDict = dict[id];
            return tempDict;
        }

        //UPDATE
        public static IDictionary<int, LocationModel> EditLocation(IDictionary<int, LocationModel> dict, int id, long longitude, long latitude, string name)
        {
            var loc = new LocationModel
            {
                Id = id,
                GeoPoint = new GeoCoordinatePortable.GeoCoordinate(latitude, longitude),
                Name = name
            };

            dict[id] = loc;
            return dict;
        }

        //DELETE
        public static IDictionary<int, LocationModel> DeleteLocation(IDictionary<int, LocationModel> dict, int id)
        {
            dict.Remove(id);
            return dict;
        }

        //TOCONSOLE
        public static void ToConsole(IDictionary<int, LocationModel> dict)
        {
            foreach (KeyValuePair<int, LocationModel> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.GeoPoint.Latitude} {kvp.Value.GeoPoint.Longitude} {kvp.Value.Name}");
            }
        }

        //TOCSV
        public static string DictToCSV(IDictionary<int, LocationModel> dict)
        {
            string toString = "";

            foreach (int key in dict.Keys)
            {
                toString += $"{key} {dict[key].GeoPoint.Latitude},{dict[key].GeoPoint.Longitude},{dict[key].Name}\n";
            }
            return toString;
        }

        //TOJSON
        public static string DictToJson(IDictionary<int, LocationModel> dict)
        {
            string toString = "";

            foreach (int key in dict.Keys)
            {
                toString += $"\"{key}\":[\"GeoPoint.Latitude\":\"{dict[key].GeoPoint.Latitude}\",\"GeoPoint.Longitude\":\"{dict[key].GeoPoint.Longitude}\",\"Name\":\"{dict[key].Name}\",";
            }
            string final = "{" + toString + "}";
            return final;
        }

    }
}
