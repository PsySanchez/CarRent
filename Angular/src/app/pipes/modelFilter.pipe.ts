import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'modelFilter'
})

export class ModelFilterPipe implements PipeTransform {

    transform(items: any[], searchText: string) {
        if (!items) { return []; }
        if (!searchText) { return items; }

        if (searchText === 'Select product') { return items; }

        return items.filter(it => {
            return it.model.toLowerCase().includes(searchText.toLowerCase());
        });
    }
}
