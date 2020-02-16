namespace Solstice
{
    using Solstice.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class Storage
    {
        public static List<Contact> contacts = new List<Contact>();

        internal static void StoreContact(Contact item)
        {
            if (contacts.Count == 0)
            {
                item.Id = 1;
                contacts.Add(item);
            }
            else
            {
                item.Id = contacts.Last().Id + 1;
                contacts.Add(item);
            }
        }

        internal static List<Contact> GetAllContacts()
        {
            return contacts;
        }

        internal static Contact GetContactById(int id)
        {
            try
            {
                return contacts.Single(c => c.Id == id);
            }
            catch
            {
                return new Contact();
            }
        }

        internal static Contact GetContactByName(string name)
        {
            return contacts.Where(c => c.Name == name).First();
        }

        internal static Contact GetContactByEmail(string email)
        {
            return contacts.Where(c => c.Email == email).First();
        }

        internal static Contact GetContactByPhone(string phone)
        {
            return contacts.Where(c => c.PhoneNumber == phone).First();
        }

        internal static bool UpdateContact(Contact item)
        {
            try
            {
                var contact = contacts.Single(c => c == item);
                contacts.Remove(contact);
                contacts.Add(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool DeleteContact(Contact item)
        {
            try
            {
                var contact = contacts.Single(c => c == item);
                contacts.Remove(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static List<Contact> GetAllFromCity(int cityCode)
        {
            return contacts.Where(c => c.Address.CityCode == cityCode).ToList();
        }

        internal static List<Contact> GetAllFromState(int stateCode)
        {
            return contacts.Where(c => c.Address.StateCode == stateCode).ToList();
        }
    }
}