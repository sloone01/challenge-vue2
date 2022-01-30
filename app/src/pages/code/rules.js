export default function getRulesList() {
    const nameRule = [
        v => !!v || 'Name is required',
        v => v.length <= 10 || 'Name must be less than 10 characters',
    ]
    const required = [
        v => !!v || 'Date Of Birth is Required',
    ]

    return { nameRule , required }
}



