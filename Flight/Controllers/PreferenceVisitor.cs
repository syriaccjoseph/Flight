using System;
using Antlr4.Runtime;
using Flight.Antlr;

using System.Collections.Generic;
using Flight.Models;
namespace Flight.Controllers
{

    public class PreferenceVisitor : PreferenceLanguageBaseVisitor<List<float[]>>
    {

        private List<AirRoutes> flightList;
        public List<PreferenceParsed> Preferences = new List<PreferenceParsed>();

        public PreferenceVisitor(List<AirRoutes> flightList)
        {
            this.flightList = flightList;
        }


        public override List<float[]> VisitParenthesisPreference(PreferenceLanguageParser.ParenthesisPreferenceContext context)
        {
            return Visit(context.preference());
        }

        public override List<float[]> VisitAndPreference(PreferenceLanguageParser.AndPreferenceContext context)
        {
            List<float[]> list1 = Visit(context.preference(0));
            List<float[]> list2 = Visit(context.preference(1));

            List<float[]> finalList = new List<float[]>();

            int loopLength = list1.Count > list2.Count ? list1.Count : list2.Count;

            Console.WriteLine(list1.Count + " " + list2.Count + " " + loopLength);

            int list1Counter = 0, list2Counter = 0;
            for (int i = 0; i < loopLength; i++)
            {
                if( list1Counter < list1.Count && list2Counter < list2.Count)
                {
                    if (list1[list1Counter][0] == list2[list2Counter][0])
                    {
                        //change the list1[i][1]
                        //finalList.Add(list1[list1Counter]);

                        finalList.Add(new float[] { list1[list1Counter][0], Math.Min(list1[list1Counter][1], list2[list2Counter][1]) });

                        list1Counter++;
                        list2Counter++;
                    }
                    else if (list1[list1Counter][0] < list2[list2Counter][0])
                    {
                        list1Counter++;
                    }
                    else
                    {
                        list2Counter++;
                    }
                }

            }


            return finalList;
        }



        public override List<float[]> VisitOrPreference(PreferenceLanguageParser.OrPreferenceContext context)
        {
            List<float[]> list1 = Visit(context.preference(0));
            List<float[]> list2 = Visit(context.preference(1));

            List<float[]> finalList = new List<float[]>();

            int loopLength = list1.Count > list2.Count ? list1.Count : list2.Count;

            Console.WriteLine(list1.Count + " " + list2.Count + " " + loopLength);

            int list1Counter = 0, list2Counter = 0;
            for (int i = 0; i < loopLength; i++)
            {
                if (list1Counter < list1.Count && list2Counter < list2.Count)
                {
                    if (list1[list1Counter][0] == list2[list2Counter][0])
                    {
                        finalList.Add(new float[] { list1[list1Counter][0], Math.Max(list1[list1Counter][1], list2[list2Counter][1]) });
                        list1Counter++;
                        list2Counter++;
                    }
                    else if (list1[list1Counter][0] < list2[list2Counter][0])
                    {
                        //finalList.Add(list1[list1Counter]);
                        list1Counter++;
                    }
                    else
                    {
                        //finalList.Add(list2[list2Counter]);
                        list2Counter++;
                    }
                }

            }
            return finalList;
        }

        public override List<float[]> VisitCompromisePreference(PreferenceLanguageParser.CompromisePreferenceContext context)
        {
            List<float[]> list1 = Visit(context.preference(0));
            List<float[]> list2 = Visit(context.preference(1));

            List<float[]> finalList = new List<float[]>();

            int loopLength = list1.Count > list2.Count ? list1.Count : list2.Count;

            Console.WriteLine(list1.Count + " " + list2.Count + " " + loopLength);

            int list1Counter = 0, list2Counter = 0;
            for (int i = 0; i < loopLength; i++)
            {
                if (list1Counter < list1.Count && list2Counter < list2.Count)
                {
                    if (list1[list1Counter][0] == list2[list2Counter][0])
                    {
                        //change the list1[i][1]
                        finalList.Add(new float[] { list1[list1Counter][0], (float)(list1[list1Counter][1] + list2[list2Counter][1]) / 2 });

                        list1Counter++;
                        list2Counter++;
                    }
                    else if (list1[list1Counter][0] < list2[list2Counter][0])
                    {
                        //finalList.Add(list1[list1Counter]);
                        list1Counter++;
                    }
                    else
                    {
                        //finalList.Add(list2[list2Counter]);
                        list2Counter++;
                    }
                }

            }
            return finalList;
        }


        public override List<float[]> VisitAtomPreference(PreferenceLanguageParser.AtomPreferenceContext context)
        {
            String name = context.PREFERENCE_NAME().GetText();
            int from = int.Parse(context.VAL(0).GetText());
            int to = int.Parse(context.VAL(1).GetText());

            List<float[]> list = new List<float[]>();

            for (int i = 0; i < this.flightList.Count; i++)
            {

                if (String.Equals(name, "price"))
                {
                    float PriceValue = (float)(this.flightList[i].Price - to) / (from - to);
                    if (PriceValue >= 0F && PriceValue <= 1F)
                    { 
                    list.Add(new float[] { i, PriceValue });
                    }

                } else if (String.Equals(name, "stops"))
                {
                    float StopValue = (float)(this.flightList[i].Stops - to) / (from - to);
                    if (StopValue >= 0F && StopValue <= 1F)
                    {
                        list.Add(new float[] { i, StopValue });
                    }

                } else if (String.Equals(name, "seats"))
                {

                    float SeatValue = (float.Parse(this.flightList[i].seatsAvailable) - from) / (to - from);

                    if (SeatValue >= 0F && SeatValue <= 1F)
                    {
                        list.Add(new float[] { i, SeatValue });
                    }

                }
            }

            return list;
        }

    }
}
