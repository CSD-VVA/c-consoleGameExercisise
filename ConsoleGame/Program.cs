using ConsoleGame;
using System;

class MainApp
{
    static void Main()
    {
        Console.CursorVisible = false;

        GUIController guiController = new GUIController();

        guiController.ShowMenu();
    }
}