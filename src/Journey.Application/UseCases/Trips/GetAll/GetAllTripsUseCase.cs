using Journey.Infrastructure;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.GetAll
{
    public class GetAllTripsUseCase
    {
        public ResponseTripsJson Execute()
        {

            var dbContext = new JourneyDBContext();

            var trips = dbContext.Trips.ToList();


            return new ResponseTripsJson
            {
                Trips = trips.Select(trip => new ResponseShortTripJson
                { 
                    Id = trip.Id, 
                    EndDate = trip.EndDate,
                    Name = trip.Name,
                    StartDate = trip.StartDate
                }).ToList()
            };
        }
    };

}

