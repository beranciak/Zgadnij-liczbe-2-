# Zgadnij-liczbe-2-



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

