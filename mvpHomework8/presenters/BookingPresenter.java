package presenters;

import models.Table;

import java.util.Collection;
import java.util.Date;
import java.util.Optional;

// Добавим компонент BookingPresenter, который позволяет
// осуществлять взаимодействие между представлением и нашей моделью
// Этот компонент является наблюдателем
public class BookingPresenter implements ViewObserver {
    // Теперь когда мы добавили интерфейс Model мы можем сказать,
    // что наш presenter зависит от нашей модели,
    // но от какой
    // представим, что модель данных поменяется
    // нужно указать, что сюда обязательно нужно передать модель
    private final Model model;
    private Collection<Table> tables;
    private View bookingView;

    public BookingPresenter(Model model, View view) {
        this.model = model; // теперь связали модель с презенторам
        this.bookingView = view;
        view.setObserver(this);
    }

    // Создадим вспомогательный метод

    /**
     * Получение списка всех столиков
     */
    public void loadTables() {
        tables = model.loadTables();
    }

    /**
     * Отобразить список столиков на представлении
     */
    public void updateView() {
        // чтобы этот метод работал надо связать presenter и view
        // создадим новый интерфейс View
        // Когда нам нужно обратиться к представлению из презентора,
        // то есть отрисовать на представлении, что то мы можем
        // обратиться к нашему View, например BookingView и вызвать
        // соответствующий метод
        // Поэтому как только добавляем новые методы на представление
        // нужно не забыть протянуть их на уровень интерфейса,
        // тогда на презенторе будит доступен метод showTables()
        // куда мы передадим список столиков, которые мы
        // предварительно получили от модели
        // Презентор это связующее звено между моделями и
        // представлением
        bookingView.showTables(tables);
    }

    public void printReservationTableResult(int reservationNo) {
        // Создадим метод в BookingView
        // После этого мы можем обратиться к представлению
        bookingView.printReservationTableResult(reservationNo);
    }

    // Создадим вспомогательный метод
    // Этот метод вызывается тогда, когда пользователь нажимает
    // на кнопку резервирования столика
    // Во многих языках программирования метода, который возникает
    // в момент отработки события он начинается со слова on

    /**
     * Произошло событие, пользователь нажал
     * на кнопку резерва столика
     * @param orderDate
     * @param tableNo
     * @param name
     */
    public void onReservationTable(Date orderDate,
                                   int tableNo,
                                   String name) {
        // Чтобы связать добавим сигнатуру метода в интерфейс
        // ViewObserver

        Optional<Table> table = tables.stream().filter(
                t -> t.getNo() == tableNo).findFirst();
        if (table.isPresent()) {
            int reservationNo = model.reservationTable(orderDate,
                                                       tableNo,
                                                       name);
            // BookingPresenter сообщает View об успешном
            // бронировании
            printReservationTableResult(reservationNo);
        }
    }

    //TODO: printChangeReservationTableResult

    //TODO: onChangeReservationTable

    public void printChangeReservationTableResult(int reservationNo) {
        // Создадим метод в BookingView
        // После этого мы можем обратиться к представлению
        bookingView.printChangeReservationTableResult(reservationNo);
    }

    public void onChangeReservationTable(int idReservation,
                                         Date reservationDate,
                                         int tableNo,
                                         String name) {

        model.deleteReservationTable(idReservation, tableNo);

        int reservationNo = model.reservationTable(reservationDate,
                                                   tableNo,
                                                   name);

        printChangeReservationTableResult(reservationNo);
    }
}
