import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'manufacturerFilter'
})

export class ManufacturerFilterPipe implements PipeTransform {

    transform(items: any[], searchText: string) {
        if (!items) { return []; }
        if (!searchText) { return items; }
        if (searchText === 'Select category') { return items; }

        return items.filter(it => {
            return it.manufacturer.toLowerCase().includes(searchText.toLowerCase());
        });
    }
}
