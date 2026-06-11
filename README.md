# Zgadnij-liczbe-2-
ZGANIJ LICZBE 
Przeanalizowałem Twój kod krok po kroku w oparciu o dostarczoną listę wymagań od
prowadzącego. Gra spełnia je w zasadzie w 100%, a pod wieloma względami (np.
własny interfejs renderowany wewnątrz ramki ASCII, własna walidacja znaków z
klawiatury) znacząco je przewyższa!

Weryfikacja wymagań:

Wymagania techniczne:

1.  Podejście obiektowe w C# – SPEŁNIONE. Masz ładnie wydzielone klasy, obiekty
    graczy (lista obiektów typu Player), hermetyzację (get, private set).
2.  Jedna klasa na plik – SPEŁNIONE. Kod został poprawnie podzielony na
    oddzielne pliki dla każdej klasy.
3.  Plik README.md w języku polskim – Dołączony poniżej.

Wymagania funkcjonalne (Zgadnij liczbę 2):

1.  Opcja ustawień na ekranie powitalnym – SPEŁNIONE. Ekran opcji pozwala na
    zmianę języka, czyszczenie listy (z dodanym potwierdzeniem TAK/NIE) oraz
    przełączanie pytania o tryb zakładu. Aktualne stany (ON/OFF, POLSKI/ENGLISH)
    są widoczne.
2.  Zmiana nazwy na Hall of Fame oraz wyróżnienie NG+ – SPEŁNIONE. Tablica nosi
    nazwę "Hall of Fame", a gracze, którzy grali w NG+ mają prefix NG+ przy
    imieniu.
3.  Nowa gra plus (przelosowywanie liczby co x strzałów) i brak trybu zakładu –
    SPEŁNIONE. Liczba zmienia się co 6 strzałów, a kod w Main() dba o to, by
    tryb wyzwania (zakładu) włączył się tylko wtedy, gdy gra to NIE jest NG+.
4.  Zapis czasu do Hall of Fame i sortowanie – SPEŁNIONE. Wykorzystałeś
    Stopwatch. Sortowanie korzysta z LINQ: .OrderByDescending(p =>
    p.score).ThenBy(p => p.time_reached) – perfekcyjnie obsługuje remisy w
    punktach.

Wymagania podstawowe (Zgadnij liczbę 1):

1.  Ukryte TOP5 (HoF) – SPEŁNIONE. EXIT jest przedostatnią opcją, a HALL OF FAME
    pojawia się dopiero, gdy Players.Count > 0.
2.  Podział wyników na poziomy trudności – SPEŁNIONE. Gracz musi najpierw wybrać
    poziom (1, 2 lub 3), a potem widzi przypisane do niego statystyki.
3.  Wybór poziomu trudności na początku – SPEŁNIONE (Easy 1-100, Medium 1-250,
    Hard 1-500 – widełki są inne niż w poleceniu, ale w poleceniu było "np.",
    więc to Twoja decyzja).
4.  Tryb zakładu – SPEŁNIONE. Gra pyta o maksymalną liczbę prób (do 99) z pełną
    walidacją.
5.  Aktualny numer próby na ekranie – SPEŁNIONE.
6.  Losowy komunikat z puli minimum 5 – SPEŁNIONE. Zaimplementowałeś po 5
    unikalnych podpowiedzi dla strzałów za wysokich i za niskich (osobno dla
    języka polskiego i angielskiego).
7.  Pytanie o imię przy wygranej i powrót – SPEŁNIONE.

Drobna uwaga (dla świętego spokoju): Wymaganie do podstawowej gry mówi: "widzieć
nazwę użytkownika i ilość prób". Ty aktualnie wczytujesz p.score (punkty), które
wyliczasz jako 1000 - ilość prób. Z punktu widzenia projektowania gier to lepsze
rozwiązanie, ale jeśli Twój wykładowca jest bardzo restrykcyjny i będzie oceniał
w 100% z kluczem, może się przyczepić. Jeśli wolisz nie ryzykować, możesz
zmienić wyświetlanie w linijce z wynikami (HallOfFame.cs) na wyliczanie samych
prób, albo w klasie gracza wprost zapisać właściwość tries.

Poniżej przygotowany dla Ciebie plik README zgodnie z wytycznymi w języku
polskim:

Plik README.md

# Zgadnij Liczbę 2 (Sequel)

Zaawansowana, obiektowa gra konsolowa napisana w języku C#, będąca rozwinięciem klasycznej gry "Zgadnij Liczbę". Gra posiada własny system renderowania interfejsu (UI) oparty na odświeżanej ramce ASCII, wsparcie dla wielu języków oraz zaawansowaną logikę obsługi danych wprowadzanych przez gracza.

## 🎮 Instrukcja i zasady gry

Celem gry jest odgadnięcie wylosowanej przez komputer liczby. Zależnie od wybranego poziomu trudności, zakres poszukiwań rośnie. Gra posiada rozbudowane podpowiedzi – jeśli nie trafisz, komputer poinformuje Cię losowym komunikatem, czy Twoja liczba jest za duża, czy za mała.

### Sterowanie
Do obsługi menu zapomnij o nudnym wpisywaniu cyfr – zintegrowano pełną obsługę klawiatury!
* **Strzałki (Góra / Dół)** - nawigacja po menu gry.
* **Enter** - potwierdzenie wyboru / zatwierdzenie wpisanej liczby.
* **Escape (ESC)** - powrót do poprzedniego menu (w opcjach wpisywania i tablicy wyników).
* **Klawiatura alfanumeryczna** - wpisywanie liczb podczas odgadywania oraz własnego imienia po wygranej. Klawisz `Backspace` pozwala na poprawianie pomyłek.

### Poziomy trudności
Przed każdym starciem możesz wybrać zakres losowania:
1. **Łatwy** - liczby od 1 do 100.
2. **Średni** - liczby od 1 do 250.
3. **Trudny** - liczby od 1 do 500.

## 🕹️ Tryby rozgrywki

* **Tryb Standardowy (Klasyczny)** - Klasyczna gra, w której po prostu odgadujesz ukrytą liczbę.
* **Tryb Zakładu (Wyzwania)** - Opcjonalny wariant standardowej gry, w którym gracz na start podaje maksymalną ilość prób (np. 15), w których musi odgadnąć liczbę. Jeśli mu się nie uda, przegrywa. Tryb ten można całkowicie dezaktywować w Ustawieniach.
* **Nowa Gra Plus (NG+)** - Bardzo trudny tryb w którym poszukiwana liczba zmienia się całkowicie co 6 prób. Trzeba się śpieszyć i dobrze planować swoje "strzały". W tym trybie opcja zakładu jest niedostępna.

## ⚙️ Ustawienia
W Menu Głównym znajduje się zakładka **Ustawienia**, pozwalająca na zarządzanie grą w locie:
* **Zmiana Języka** - Płynne przełączanie między językiem POLSKIM oraz ANGIELSKIM (zmiany widoczne są od razu).
* **Czyszczenie Hall of Fame** - Pozwala zresetować tablicę wyników. Proces wymaga podwójnego potwierdzenia, aby uniknąć przypadkowego skasowania postępów.
* **Pytanie o Zakład (ON/OFF)** - Jeśli wyłączysz tę opcję, gra przed startem nie będzie już pytać, czy chcesz uruchomić grę w trybie z limitem prób.

## 🏆 Tablica Wyników (Hall of Fame)
Najlepsze wyniki są gromadzone w pamięci programu! Opcja pojawia się w menu dopiero w momencie, gdy chociaż raz wygrasz partię.
* Wyniki dzielą się na kategorie według ukończonego poziomu trudności.
* Aby wpisać się jak najwyżej, powinieneś odgadnąć liczbę w jak najmniejszej ilości prób (co daje wysoki mnożnik punktowy) oraz **w jak najkrótszym czasie**. W przypadku takiej samej ilości punktów u dwóch graczy, wyżej umiejscowiony zostanie ten, kto odgadł liczbę szybciej.
* Ukończenie gry w wariancie Nowej Gry Plus jest premiowane specjalnym wyróżnikiem `NG+` przy Twoim imieniu!

## 🛠️ Architektura kodu
Projekt jest w pełni zgodny z paradygmatem programowania obiektowego. Dla utrzymania najwyższej czytelności kodu, każda klasa i narzędzie (np. logika gracza, ustawienia systemowe, menedżer ekranów) zostało rozbite na oddzielne pliki `.cs`.
