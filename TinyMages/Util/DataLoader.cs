using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using TinyMages.Effects;
using TinyMages.Characters;

namespace TinyMages.Util
{
    public class DataLoader
    {
        #region Константы

        private const string MagesFilename = @"Data\Mages.xml";
        private const string EffectsFilename = @"Data\Effects.xml";

        #endregion

        #region Свойства

        public static List<IEffect> Effects { get; }
        public static List<Mage> Mages { get; }

        #endregion

        #region Приватные методы

        static DataLoader()
        {
            Effects = LoadEffects();
            Mages  = LoadMages();
        }

        private static List<Mage> LoadMages()
        {
            var mages = new List<Mage>();

            var xml = File.ReadAllText(MagesFilename);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            foreach (XmlNode mageXml in xmlDoc.DocumentElement["Mages"])
            {
                string name = mageXml["Name"].InnerText;
                double health = double.Parse(mageXml["Health"].InnerText);
                double mana = double.Parse(mageXml["Mana"].InnerText);
                double strength = double.Parse(mageXml["Strength"].InnerText);
                double defense = double.Parse(mageXml["Defense"].InnerText);

                var spellbook = new List<IEffect>();
                var preparedEffects = new List<IEffect>();
                var appliedEffects = new List<AppliedEffect>();
                if (mageXml["SpellBook"] != null)
                {
                    if (mageXml["SpellBook"].Attributes["LearnAll"] != null && mageXml["SpellBook"].Attributes["LearnAll"].Value == "True")
                    {
                        spellbook = new List<IEffect>(Effects);
                    }

                    foreach (XmlNode effectXml in mageXml["SpellBook"])
                    {
                        var effect = GetEffectByXmlNode(effectXml);

                        if (effectXml.Attributes["Learned"] != null)
                        {
                            var learnedAttribute = effectXml.Attributes["Learned"].Value;
                            if (learnedAttribute == "True" && !spellbook.Contains(effect))
                            {
                                spellbook.Add(effect);
                            }
                            if (learnedAttribute == "False" && spellbook.Contains(effect))
                            {
                                spellbook.Remove(effect);
                            }
                        }
                        if (effectXml.Attributes["Prepared"] != null && effectXml.Attributes["Prepared"].Value == "True")
                        {
                            preparedEffects.Add(effect);
                        }
                        if (effectXml.Attributes["Applied"] != null && effectXml.Attributes["Applied"].Value == "True")
                        {
                            appliedEffects.Add(new AppliedEffect(effect, 1));
                        }
                    }
                }

                var mage = new Mage(name, health, mana, strength, defense, spellbook, preparedEffects, appliedEffects);
                mages.Add(mage);
            }
            return mages;
        }

        private static IEffect GetEffectByXmlNode(XmlNode effectXml)
        {
            return Effects.First(e => e.Name == effectXml.Attributes["Name"].Value);
        }

        private static List<IEffect> LoadEffects()
        {
            var ellects = new List<IEffect>();

            var xml = File.ReadAllText(EffectsFilename);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            foreach (XmlNode effectXml in xmlDoc.DocumentElement["Effects"])
            {
                string effectName = effectXml["EffectName"].InnerText;
                string name = effectXml["Name"].InnerText;
                Nature nature = (Nature)Enum.Parse(typeof(Nature), effectXml["Nature"].InnerText);
                double mana = double.Parse(effectXml["Mana"].InnerText);
                double strength = double.Parse(effectXml["Strength"].InnerText);
                int duration = 0;
                if (effectName.IndexOf("Continuous") >= 0)
                {
                    duration = int.Parse(effectXml["Duration"].InnerText);
                }
                ellects.Add(EffectHelper.Create(effectName, nature, name, mana, strength, duration));
            }
            return ellects;
        }

        #endregion
    }
}
