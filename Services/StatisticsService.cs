using MongoDB.Driver;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Models;
using eventGestion.Models.EventItems;

namespace EventManagement.Services
{
    public class StatisticsService
    {
        private readonly IMongoCollection<Event> _eventsCollection;

        public StatisticsService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("EventManagementDB");
            _eventsCollection = database.GetCollection<Event>("Events");
        }

        // Méthode pour obtenir le nombre d'événements
        public async Task<int> GetEventCountAsync()
        {
            return (int)await _eventsCollection.CountDocumentsAsync(FilterDefinition<Event>.Empty);
        }

        // Méthode pour obtenir l'événement avec le plus grand nombre de participants
        public async Task<Event> GetEventWithMostParticipantsAsync()
        {
            return await _eventsCollection
                .Find(FilterDefinition<Event>.Empty)
                .SortByDescending(e => e.MaxParticipants)
                .FirstOrDefaultAsync();
        }

        // Méthode pour calculer la moyenne des participants
        public async Task<double> GetAverageParticipantsAsync()
        {
            var events = await _eventsCollection.Find(FilterDefinition<Event>.Empty).ToListAsync();
            if (events.Count == 0)
                return 0;

            return events.Average(e => e.MaxParticipants);
        }

        // Exemple de méthode pour récupérer les événements ayant un nombre de participants supérieur à une valeur
        public async Task<List<Event>> GetEventsWithParticipantsAboveAsync(int threshold)
        {
            return await _eventsCollection
                .Find(e => e.MaxParticipants > threshold)
                .ToListAsync();
        }

        // Méthode pour calculer les événements dans une plage de dates
        public async Task<List<Event>> GetEventsInDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var filter = Builders<Event>.Filter.Gte(e => e.Date, startDate) &
                         Builders<Event>.Filter.Lte(e => e.Date, endDate);
            return await _eventsCollection.Find(filter).ToListAsync();
        }

        // Méthode pour ajouter une statistique (par exemple, un événement)
        public async Task CreateEventAsync(Event newEvent)
        {
            await _eventsCollection.InsertOneAsync(newEvent);
        }
    }
}


