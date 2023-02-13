package views;

import models.Table;
import presenters.View;
import presenters.ViewObserver;

import java.util.Collection;
import java.util.Date;

// Добавляем компанент BookingView
// этот компонент должен визуализировать данные
// вместо BookingView может быть и форма десктопного
// приложения и какие то компоненты визуализации в рамках
// мобильных приложений и так далее
// Важно как мы должны связать три наших компонента TableModel,
// BookingPresenter и BookingView
// Первое правило связывания компонентов говорит, что все
// компоненты должны связываться через интерфейсы,
// то есть мы не должны зашивать зависимости одних классов от
// других
// Этот компонент является тем кто возбуждаем события
// Когда какое то событие возбуждается на компоненте View
// мы должны разослать нашим наблюдателям сигнал о том что это
// событие возбудилось, то есть на компоненте BookingView
// появляется новая переменная ViewObserver observer
public class BookingView implements View {

    private ViewObserver observer;

    // Этот метод позволит передать нашего обсервера
    // Чтобы вызвать этот метод его надо передать в View
    public void setObserver(ViewObserver observer) {
        this.observer = observer; // инициализируем нашего
                                  // наблюдателя
    }
    // Отобразим все столики в ресторане
    public void showTables(Collection<Table> tables) {
        // кто то в частности презентор передаст нам
        // на представление список наших столиков и мы отобразим
        // в рамках нашего консольного преложения все эти столики,
        // то есть мы пройдём по всем этим столикам и просто
        // выведем на экран
        for(Table table : tables) {
            System.out.println(table);
        }
    }

    public void reservationTable(Date orderDate,
                                 int tableNo,
                                 String name) {
        observer.onReservationTable(orderDate, tableNo, name);

    }

    /**
     * Действие клиента (пользователь нажал на кнопку бронирования),
     * бронирование столика
     * @param reservationNo
     */
    public void printReservationTableResult(int reservationNo) {
        System.out.printf("Столик успешно забронирован. " +
                "Номер вашей брони: #%d\n", reservationNo);
        // Так как мы взаимодействуем с интерфейсом сразу добавляем
        // его в интерфейс View
    }



    /**
     * Действие клиента (пользователь нажал на кнопку изменения
     * бронирования),
     * старую бронь отменить
     * новую бронь добавить
     *
     * @param oldReservation
     * @param orderDate
     * @param tableNo
     * @param name
     */
    public void changeReservationTable(int oldReservation,
                                       Date orderDate,
                                       int tableNo,
                                       String name) {

        observer.onChangeReservationTable(oldReservation,
                                          orderDate,
                                          tableNo,
                                          name);

    }

    public void printChangeReservationTableResult(int reservationNo) {
        System.out.printf("Столик успешно забронирован: #%d\n", reservationNo);
    }
}
