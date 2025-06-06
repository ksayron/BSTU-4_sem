using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KNP_Library.Modules.ViewModel
{
    public class Commands : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value!;
            remove => CommandManager.RequerySuggested -= value!;
        }
    }
    public interface IUndoableCommand
    {
        void Execute();
        void Undo();
    }

    public class AddBookCommand : IUndoableCommand
    {
        private readonly BookRepository _repository;
        private readonly Book _book;

        public AddBookCommand(BookRepository repository, Book book)
        {
            _repository = repository;
            _book = book;
        }

        public void Execute()
        {
            _book.Id = 0;
            _repository.AddBook(_book);
        }

        public void Undo()
        {
            _repository.DeleteBookById(_book.Id);
        }
    }
    public class DeleteBookCommand : IUndoableCommand
    {
        private readonly BookRepository _repository;
        private readonly Book _book;

        public DeleteBookCommand(BookRepository repository, Book book)
        {
            _repository = repository;
            _book = book;
        }

        public void Execute()
        {
            _repository.DeleteBookById(_book.Id);
        }

        public void Undo()
        {
            _book.Id = 0;
            _repository.AddBook(_book);
        }
    }

    public class EditBookCommand : IUndoableCommand
    {
        private readonly BookRepository _repository;
        private readonly Book _oldBook;
        private readonly Book _newBook;

        public EditBookCommand(BookRepository repository, Book oldBook, Book newBook)
        {
            _repository = repository;
            _oldBook = oldBook;
            _newBook = newBook;
        }

        public void Execute()
        {
            _repository.UpdateBook(_oldBook.Id,_newBook);
        }

        public void Undo()
        {
            _repository.UpdateBook(_oldBook.Id,_oldBook);
        }
    }


}
