using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using ExpertSystemCore;

namespace ExpertSystemInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExpertSystem ExpertSystem = new ExpertSystemCore.ExpertSystem();

        public MainWindow()
        {
            InitializeComponent();
            Facts.ItemsSource = null;

        }

        private void SelectFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "XML files (*.xml)|*.xml";

            Nullable<bool> isOpened = dlg.ShowDialog();

            if (isOpened == true)
            {
                string filename = dlg.FileName;
                var document = XDocument.Load(filename).Root;
                var facts = document.Element("Facts");

                var allConditions = document.Element("Conditions");
                var simpleConditions = allConditions.Element("SimpleConditions");
                var conditionsAnd = allConditions.Element("ConditionsAnd");
                var conditionsOr = allConditions.Element("ConditionsOr");

                KnowledgeBase.Facts = new System.Collections.ObjectModel.ObservableCollection<Fact>();
                KnowledgeBase.Conditions = new System.Collections.ObjectModel.ObservableCollection<AbstractCondition>();
                // заполняем факты из файла
                try
                {
                    foreach (XElement fact in facts.Nodes())
                    {
                        KnowledgeBase.Facts.Add(new Fact(
                            fact.Attribute("Value").Value,
                            fact.Attribute("Object").Value
                            ));
                    }
                }
                catch { MessageBox.Show("Ошибка при чтении фактов. Проверьте целостность базы", "Ошибка!"); }

                //заполняем простые условия
                try
                {
                    foreach (XElement simpleCondition in simpleConditions.Nodes())
                    {
                        KnowledgeBase.Conditions.Add(new SimpleCondition(
                            simpleCondition.Attribute("Value").Value,
                            simpleCondition.Attribute("Result").Value
                            ));
                    }
                } catch { MessageBox.Show("Ошибка при чтении простых условий. Проверьте целостность базы", "Ошибка!"); }

                string result;
                var tempConditions = new List<AbstractCondition>();
                //заполняем сложные условия И
                try
                {
                    foreach (XElement conditionAnd in conditionsAnd.Nodes())
                    {
                        result = conditionAnd.Attribute("Result").Value;
                        foreach (XElement cond in conditionAnd.Elements("Condition"))
                        {
                            tempConditions.Add(new SimpleCondition(cond.Attribute("Value").Value, result));
                        }
                        KnowledgeBase.Conditions.Add(new ConditionAnd(tempConditions, result));
                        tempConditions = new List<AbstractCondition>();
                    }
                }
                catch { MessageBox.Show("Ошибка при чтении условий \"И\". Проверьте целостность базы", "Ошибка!"); }
                //заполняем сложные условия ИЛИ
                try
                {
                    foreach (XElement conditionOr in conditionsOr.Nodes())
                    {
                        result = conditionOr.Attribute("Result").Value;
                        foreach (XElement cond in conditionOr.Elements("Condition"))
                        {
                            tempConditions.Add(new SimpleCondition(cond.Attribute("Value").Value, result));
                        }
                        KnowledgeBase.Conditions.Add(new ConditionOr(tempConditions, result));
                        tempConditions = new List<AbstractCondition>();
                    }
                }
                catch { MessageBox.Show("Ошибка при чтении условий \"ИЛИ\". Проверьте целостность базы", "Ошибка!"); }

                Facts.ItemsSource = KnowledgeBase.Facts;
                Facts.Items.Refresh();
                MessageBox.Show("База успешно загрузилась!", "Успех!");

            }
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            var result = ExpertSystem.checkHypothesis(HypObj.Text, HypValue.Text);
            Result.Text = "Результат: " + result;
        }
    }
}
