using InteractorAbstraction;
using Repository;
using System;

namespace InteractorImplementation
{
    internal class CommandRemoveStudent : IRemoveStudent
    {
        private readonly IStudentRepository _repository;

        public CommandRemoveStudent(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            try
            {
                _repository.Remove(id);
            }
            catch (Exception exc)
            {
                throw new StudentException("Error while remove student!", exc);
            }
        }
    }
}