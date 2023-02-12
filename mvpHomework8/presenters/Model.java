package presenters;

import models.Table;

import java.util.Collection;
import java.util.Date;

// В рамках этого интерфейса будим возвращать список столиков,
// а так же будим резервировать новый столик
public interface Model {

    Collection<Table>loadTables();

    int reservationTable(
            Date reservationDate, int tableNo, String name);
}

// Теперь мы можем имплементировать данный интерфейс в контексте
// главной модели TableModel
