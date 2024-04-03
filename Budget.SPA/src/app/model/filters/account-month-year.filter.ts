import { MonthYear } from '@corporate/model';


export class FilterAccountMonthYear {
    idAccount: number = null;
    monthYear: MonthYear = null; // doit etre null pour plan not AS //new MonthYear(); // this.getMonthYear();

    // getMonthYear() {
    //     var currentDate = new Date();
    //     currentDate.setMonth(currentDate.getMonth()-1);
    //     var id = currentDate.getMonth()+1;
    //     let month =  DateTimeFactory.getMonths.filter(x=>x.id===id)[0];
    //     let monthYear = <IMonthYear> {
    //         month: month,
    //         year: currentDate.getFullYear()
    //     }
    //     return monthYear;
    // }

}
