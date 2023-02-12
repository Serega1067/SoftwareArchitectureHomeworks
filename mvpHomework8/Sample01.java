import models.TableModel;
import presenters.BookingPresenter;
import views.BookingView;

import java.util.Date;

public class Sample01 {
    public static void main(String[] args) {
        // С начала инициализирую модель данных
        TableModel model = new TableModel();

        // Далее инициализирую моё представление
        BookingView view = new BookingView();

        // Далее инициализирую мой презентер
        BookingPresenter bookingPresenter = new BookingPresenter(
                                            model,
                                            view);
        // Таким оброзом после инициализации всех компонентов
        // приложения наш презентор может подать первичный сигнал
        bookingPresenter.loadTables(); // презентер говарит мы должны
                                       // загрузить список всех
                                       // столиков
        bookingPresenter.updateView(); // отобразить все
                                       // эти столики в рамках
                                       // представления в данном
                                       // случае в консоли

        // Дальше пользователь выбирает столик и нажимает на кнопку

        // С эмулируем нажатие на кнопку
        view.reservationTable(new Date(), 3, "Сергей");

    }
}
