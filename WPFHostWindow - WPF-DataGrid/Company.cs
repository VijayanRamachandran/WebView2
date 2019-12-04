/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2019. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFHostWindow.Annotations;

namespace WPFHostWindow
{
    public class Company : INotifyPropertyChanged
    {
        private String myId = String.Empty;
        private String myName = String.Empty;
        private String myCountry = String.Empty;
        private String myContact = String.Empty;

        public String Id
        {
            get { return myId; }
            set
            {
                myId = value;
                OnPropertyChanged();
            }
        }

        public String Name
        {
            get { return myName; }
            set
            {
                myName = value;
                OnPropertyChanged();
            }
        }

        public String Contact
        {
            get { return myContact; }
            set
            {
                myContact = value;
                OnPropertyChanged();
            }
        }

        public String Country
        {
            get { return myCountry; }
            set
            {
                myCountry = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ObservableCollection<Company> GetCompanies()
        {
            var companies = new ObservableCollection<Company>();

            companies.Add(new Company()
            {
                Id = "1",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "2",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "3",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "4",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "5",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "6",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "7",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "8",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "9",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "10",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "11",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "12",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "13",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "14",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "15",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "16",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "17",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "18",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "19",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "20",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "21",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "22",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "23",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "24",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "25",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "26",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "27",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "28",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "29",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "30",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "31", Name= "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "32",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "33",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "34",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "35",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "36",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "37",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "38",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "39",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "40",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "41",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "42",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "43",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "44",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "45",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "46",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "47",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "48",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "49",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "50",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "51",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "52",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "53",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "54",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "55",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "56",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "57",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "58",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "59",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "60",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "61",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "62",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "63",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "64",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "65",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "66",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "67",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "68",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "69",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "70",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "71",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "72",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "73",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "74",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "75",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "76",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "77",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "78",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "79",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "80",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "81",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "82",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "83",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "84",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "85",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "86",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "87",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "88",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "89",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "90",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "91",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "92",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "93",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "94",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "95",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "96",
                Name = "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            companies.Add(new Company()
            {
                Id = "97",
                Name = "Alfreds Futterkiste",
                Contact = "Maria Anders",
                Country = "Germany"
            });
            companies.Add(new Company()
            {
                Id = "98",
                Name = "Centro comercial Moctezuma",
                Contact = "Francisco Chang",
                Country = "Mexico"
            });
            companies.Add(new Company()
            {
                Id = "99",
                Name = "Ernst Handel",
                Contact = "Roland Mendel",
                Country = "Austria"
            });
            companies.Add(new Company()
            {
                Id = "100",
                Name = "Island Trading",
                Contact = "Helen Bennett",
                Country = "UK"
            });
            companies.Add(new Company()
            {
                Id = "101",
                Name = "Laughing Bacchus Winecellars",
                Contact = "Yoshi Tannamuri",
                Country = "Canada"
            });
            companies.Add(new Company()
            {
                Id = "102", Name= "Magazzini Alimentari Riuniti",
                Contact = "Giovanni Rovelli",
                Country = "Italy"
            });

            return companies;
        }
    }
}
