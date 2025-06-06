using KNP_Library.Modules.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.ViewModel
{
    public class UndoRedoManager
    {
        private readonly Stack<IUndoableCommand> _undoStack = new();
        public  int UndoStackCount => _undoStack.Count;
        private readonly Stack<IUndoableCommand> _redoStack = new();
        public int RedoStackCount => _redoStack.Count;

        public void ExecuteCommand(IUndoableCommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); 
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
        }
    }
}
