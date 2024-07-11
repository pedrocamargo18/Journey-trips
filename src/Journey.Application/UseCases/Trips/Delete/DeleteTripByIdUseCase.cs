using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete
{
    public class DeleteTripByIdUseCase
    {

        public void Execute(Guid id)
        {
            var dbContext = new JourneyDBContext();

            //Usando funcao Lambda pra comparar id da entidade trips com o id que vem no parametro
            //se encontrar devolve na variavel trip
            //usar firstOrDefault valida se existe esse ID 
            //se usar apenas o First, vc garante que existe o ID
            var trip = dbContext
                .Trips
                .Include(trip => trip.Activities)//Esse include faz o join com a tabela atividades e retorna preenchido a lista
                .FirstOrDefault(trip => trip.Id == id);

            if (trip is null)
            {
                throw new NotFoundException(ResourceErrorMessages.VIAGEM_NOT_FOUND);
            }

        }
    }
}
