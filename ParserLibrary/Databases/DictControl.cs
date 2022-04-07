using System;
using System.Collections.Generic;
using ParserLibrary.Models;

namespace ParserLibrary.Databases
{
    public class DictControl
    {
        public static DictModel dmodel = new DictModel();

        public static DictModel CreateDict(string csvFile)
        {
            List<LocationModel> models = ParserControl.GetAllLocations(csvFile);

            foreach (LocationModel model in models)
            {
                dmodel.GlobalDict.Add(Int32.Parse(model.Id.ToString()), model);
            }
            return dmodel;
        }

    }
}
