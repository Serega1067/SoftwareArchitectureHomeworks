package models;

import presenters.Model;

import java.util.Collection;
import java.util.ArrayList;
import java.util.Date;
import java.util.Optional;

// каким то оброзом этот компонент связан с базой данных
public class TableModel implements Model {

    // создадим как бы связь с базой данных
    private Collection<Table> tables;

    public Collection<Table> loadTables() {

        // вместо связи с базой данных пропишим линивую инициализацию
        // при первичном доступе к столикам создадим новую коллекцию
        if (tables == null)
            tables = new ArrayList<>();

        // и заполним эту коллекцию несколькими столиками
        Table t = new Table();
        tables.add(t);
        tables.add(new Table());
        tables.add(new Table());
        tables.add(new Table());
        tables.add(new Table());

        // возвращаем столики
        // эта модель позволяем возвращать все столики в кафе
        // вместо этого кода можно было бы обратиться через
        // какой нибудь контекст как это делали в рамках чистой
        // архитектуры к базе данных и она вернула бы актуальное
        // количество столиков
        return tables;

    }

    // добавим функцию бронирования столиков
    // создадим новый метод

    /**
     * Бронирование столика
     * @param reservationDate дата бронирования
     * @param tableNo номер столика
     * @param name имя клиента
     * @return номер брони
     */
    public int reservationTable(Date reservationDate,
                                int tableNo,
                                String name) {
        // применяем объект Optional потому что если вы что то
        // неправильно написали то Optional не будит содержать
        // объект типо table
        Optional<Table> table = loadTables().stream().filter(
                t -> t.getNo() == tableNo).findFirst();
        
        // если table.isPresent(), то есть данные существуют, тогда
        // мы создаём новый объект резерва
        //TODO: Проверка резерва
        if (table.isPresent()) {
            Reservation reservation = new Reservation(
                                      reservationDate, name);
            
            // дальше резервируем столик
            table.get().getReservations().add(reservation);
            
            // возвращаем идентификатор резерва
            return reservation.getId();
        }
        // если if не сработал возвращаем исключение
        throw new RuntimeException("Некорректный номер столика.");
    }

    //TODO: changeReservationTable

    public void deleteReservationTable(int idReservation,
                                       int tableNoOld) {
        Optional<Table> table = loadTables().stream().filter(
                t -> t.getNo() == tableNoOld).findFirst();
        if (table.isPresent()) {
            table.get().getReservations().removeIf(
                    r -> r.getId() == idReservation);
            System.out.println("Заказ #" + idReservation + " отменён");
        }

    }

    public int changeReservationTable(int idReservation,
                                      Date reservationDate,
                                      int tableNo,
                                      String name) {

        deleteReservationTable(idReservation, tableNo);

        return reservationTable(reservationDate, tableNo, name);
    }
}
