function addTenMinutes(year, month, day, hour, minutes) {

    let addMinutes = (dt, minutes) => new Date(dt.getTime() + minutes * 60000);

    let addZero = (x) => x <= 9 ? "0" + x :  x

    let formatDate = (d) => {
        let yyyy = d.getFullYear()
        let MM = addZero(d.getMonth() + 1)
        let dd = addZero(d.getDate())
        let hh = addZero(d.getHours())
        let mm = addZero(d.getMinutes())

        return `${yyyy}-${MM}-${dd} ${hh}:${mm}`
    }

    let date = new Date(year, month - 1, day, hour, minutes)
    date = addMinutes(date, 10)

    return formatDate(date)

}

function addFromEdges(list) {

    let result = []
    const lastIndex = list.length - 1

    for (let leftIndex = 0; leftIndex < list.length / 2; leftIndex++) {
        let rightIndex = lastIndex - leftIndex
        if (leftIndex === rightIndex)
            result.push(list[leftIndex])
        else
            result.push(list[leftIndex] + list[rightIndex])
    }
    return result;
}

function addFromEdges_recursive(list) {

    if (list.length === 0) return []
    if (list.length === 1) return [list[0]]

    let first = list[0]
    let middle = list.slice(1, list.length-1)
    let last = list[list.length-1]
    
    return [first+last]
        .concat(addFromEdges_recursive(middle))

}

function nearbyElement(list, index) {

    // Invalid arguments

    if (index > list.length || index <= 0)
        return null

    // Edge cases - just one element

    if (index === 1 && list.length === 1)
        return [list[0]]

    // Edge cases - far left

    if (index === 1 && list.length >=2)
        return [list[0], list[1]]

    // Edge cases - far right

    if (index === list.length)
        return [list[list.length - 2], list[list.length - 1]]

    // Normal case

    return [list[index - 1], list[index], list[index + 1]]
}






