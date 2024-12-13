<template>
  <div class="flex w-full flex-col items-center justify-center py-8 text-slate-800 ">
    <!-- File Upload Section -->

    <div class="flex w-full flex-col items-center gap-6 rounded-lg p-6 md:w-[32rem] ">
      <!-- Hidden Input -->
      <input type="file" multiple hidden ref="fileInputRef" @change="handleFileUpload" />

      <!-- File Selection Button -->
      <button type="button"
              class="rounded-full bg-gradient-to-br from-indigo-400 to-indigo-300 px-4 py-2 text-xs text-slate-100 shadow-md shadow-indigo-400 hover:from-indigo-300 hover:to-indigo-400 focus:border-2 focus:border-indigo-500 focus:outline-none "
              @click="triggerFileUpload"
              :class="{'cursor-not-allowed opacity-50': uploadedFiles.length >= maxFilesToUpload}"
              :disabled="uploadedFiles.length >= maxFilesToUpload">
        <span v-if="uploadedFiles.length === 0">Choose Files To Upload</span>
        <span v-else>Add More Files</span>
      </button>
      <p v-if="isFileCountError" role="alert" aria-live="polite" class="text-center text-xs text-red-400">
        You can only upload a maximum of {{ maxFilesToUpload }} files.
      </p>
      <p v-else-if="isFileTypeError" role="alert" aria-live="polite" class="text-center text-xs text-red-400">
        Only Images and PDF Files are allowed.
      </p>
      <p v-else-if="isFileSizeError" role="alert" aria-live="polite" class="text-center text-xs text-red-400">
        Maximum file size is {{ maxFileSizeToUpload }}MB.
      </p>
      <p v-else class="text-center text-xs" style="color:#11120d">
        Up to {{ maxFilesToUpload }} files, each within {{ maxFileSizeToUpload }}MB.
      </p>

      <!-- Uploaded Files Section -->
      <div v-if="uploadedFiles.length > 0" class="space-y-2">
        <div v-for="(file, index) in uploadedFiles" :key="file.name" class="flex w-full items-center rounded-lg bg-indigo-100 p-2 ">
          <!-- File Details -->
          <div class="w-10/12 px-2">
            <h4 class="truncate text-base">{{ file.name }}</h4>
            <p class="text-xs">{{ formatFileSize(file.size) }}</p>
          </div>
          <!-- Remove File Button -->
          <div @click="removeUploadedFile(index)" class="size-6 w-1/12 cursor-pointer rounded-lg text-center hover:text-red-400">
            <XMarkIcon class="size-6" />
          </div>
        </div>
      </div>

      <!-- Submit Button -->
      <button v-if="uploadedFiles.length > 0" @click="handleSubmit"
              class="rounded-full px-6 py-2 text-slate-100"
              :class="uploadSuccess ? 'bg-gradient-to-br from-green-400 to-green-300 shadow-md shadow-green-400' : uploadFailed ? 'bg-gradient-to-br from-red-400 to-red-300 shadow-md shadow-red-400' : 'bg-gradient-to-br from-indigo-400 to-indigo-300 shadow-md shadow-indigo-400 hover:from-indigo-300 hover:to-indigo-400  '"
              :disabled="uploadedFiles.length === 0">
        <span v-if="uploadSuccess" class="flex gap-2"><CheckIcon class="size-6" /> Success</span>
        <span v-else-if="uploadFailed" class="flex gap-2"><XMarkIcon class="size-6" /> Unsuccessful</span>
        <span v-else>Upload</span>
      </button>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { CheckIcon, XMarkIcon } from "@heroicons/vue/24/solid";
//import UploadService from "../../services/UploadService.js";

// Props for the File Upload Component
const props = defineProps({
  maxFilesToUpload: {
    type: Number,
    default: 1,
  },
  maxFileSizeToUpload: {
    type: Number,
    default: 5,
  },
  allowedTypes: {
    type: Array,
    default: () => ["image/jpeg", "image/jpg", "image/png", "application/pdf"],
  },
  submitHandler: {
    type: Function,
    default: () => {},
  },
});

// Reactive Variables
const uploadedFiles = ref([]);
const fileInputRef = ref(null);
const uploadSuccess = ref(false);
const uploadFailed = ref(false);
const isFileCountError = ref(false);
const isFileSizeError = ref(false);
const isFileTypeError = ref(false);

// Functions
function triggerFileUpload() {
  fileInputRef.value.click();
}

function handleFileUpload(event) {
  const files = event.target.files;
  const remainingSlots = props.maxFilesToUpload - uploadedFiles.value.length;

  const validFiles = [];
  const oversizedFiles = [];
  const invalidTypeFiles = [];

  // Filter Files Based On Size & Type
  for (let file of files) {
    const maxSize = props.maxFileSizeToUpload * 1024 * 1024; // Convert to bytes
    if (file.size > maxSize) {
      oversizedFiles.push(file);
    } else if (!props.allowedTypes.includes(file.type)) {
      invalidTypeFiles.push(file);
    } else {
      validFiles.push(file);
    }
  }

  // Handle Over-sized Files
  if (oversizedFiles.length > 0) {
    isFileSizeError.value = true;
    setTimeout(() => {
      isFileSizeError.value = false;
    }, 3000);
  }

  // Handle Invalid Files
  if (invalidTypeFiles.length > 0) {
    isFileTypeError.value = true;
    setTimeout(() => {
      isFileTypeError.value = false;
    }, 3000);
  }

  // Handle Valid Files
  if (validFiles.length > remainingSlots) {
    validFiles.slice(0, remainingSlots).forEach((file) => {
      uploadedFiles.value.push({ name: file.name, size: file.size, type: file.type || "unknown" });
    });
    isFileCountError.value = true;
    setTimeout(() => {
      isFileCountError.value = false;
    }, 3000);
  } else {
    validFiles.forEach((file) => {
      uploadedFiles.value.push({ name: file.name, size: file.size, type: file.type || "unknown" });
    });
  }
}

function handleSubmit() {
  if (props.submitHandler) {
    props.submitHandler(uploadedFiles.value);
  }
  // Resetting after submission
  uploadSuccess.value = true;
}

function removeUploadedFile(index) {
  uploadedFiles.value.splice(index, 1);
}

function formatFileSize(bytes) {
  return bytes >= 1024 * 1024
      ? `${(bytes / (1024 * 1024)).toFixed(2)} MB`
      : `${(bytes / 1024).toFixed(2)} KB`;
}
</script>
