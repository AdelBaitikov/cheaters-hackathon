using TaskManager.Services;
using TaskManager.UI;

var database = new DatabaseManager();
var app = new AppUI(database);
app.Start();