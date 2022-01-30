import { ref } from "@vue/composition-api";

export default function useGeneralObjects()
{
    const student = ref({
        Name: '',
        DateOfBirth: new Date().toISOString().substr(0, 10),
        ClassId: 0,
        CountryId: 0
    })
    const general = ref({  Name : ""})
    return { student,general }
}
